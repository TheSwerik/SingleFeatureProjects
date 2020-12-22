using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class TransparentWindow : MonoBehaviour
{
    private const int GwlExstyle = -20;
    private const uint WsExLayered = 0x00080000;
    private const uint WsExTransparent = 0x00000020;
    private const uint LwaColorkey = 0x00000001;
    private static readonly IntPtr HwndTopmost = new IntPtr(-1);

    [SerializeField] private bool debug;
    private EventSystem _eventSystem;
    private IntPtr _hWnd;

    private void Start()
    {
        _eventSystem = EventSystem.current;

        _hWnd = GetActiveWindow();
        var margins = new Margins {CxLeftWidth = -1};
        DwmExtendFrameIntoClientArea(_hWnd, ref margins);
        Application.runInBackground = true;

        #if !UNITY_EDITOR
        if (debug) return;
        // Clickthrough:
        SetWindowLong(_hWnd, GwlExstyle, WsExLayered | WsExTransparent);
        
        // ALways on Top:
        SetWindowPos(_hWnd, HwndTopmost, 0, 0, 0, 0, 0);
        #endif
    }

    private void Update()
    {
        #if !UNITY_EDITOR
        if (debug) return;
        SetClickthrough(!eventSystem.IsPointerOverGameObject());
        #endif
    }

    private void SetClickthrough(bool clickthrough)
    {
        SetWindowLong(_hWnd, GwlExstyle, clickthrough ? WsExLayered | WsExTransparent : WsExLayered);
    }

    private struct Margins
    {
        public int CxLeftWidth;
        public int CxRightWidth;
        public int CyTopHeight;
        public int CyBottomHeight;
    }

    #region DllImports

    [DllImport("user32.dll")] private static extern IntPtr GetActiveWindow();
    [DllImport("Dwmapi.dll")] private static extern uint DwmExtendFrameIntoClientArea(IntPtr hWnd, ref Margins margins);
    [DllImport("user32.dll")] private static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy,
                                            uint uFlags);

    #endregion
}