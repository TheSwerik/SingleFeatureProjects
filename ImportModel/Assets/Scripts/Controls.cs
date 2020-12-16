using System;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public InputActions InputActions { get; private set; }
    private void Awake() { InputActions = new InputActions(); }
    private void OnEnable() { InputActions.Enable(); }
    private void OnDisable() { InputActions.Disable(); }
    private void OnDestroy() { InputActions.Dispose(); }
}
