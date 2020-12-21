using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class MenuControls : MonoBehaviour
{
    public void Exit()
    {
        Process.GetCurrentProcess().Kill();
        // Application.Quit();
        Debug.Log("QUIT");
    }
}