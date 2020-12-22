using UnityEngine;

public class Controls : MonoBehaviour
{
    private InputActions _inputActions;

    private void Awake() { _inputActions = new InputActions(); }
    private void OnEnable() { _inputActions.Enable(); }

    private void OnDisable() { _inputActions.Disable(); }

    private void OnDestroy() { _inputActions.Dispose(); }

    #region Public Methods

    public Vector2 GetMoveDirection() { return _inputActions.Player.Move.ReadValue<Vector2>(); }
    public Vector2 GetMousePosition() { return _inputActions.UI.Point.ReadValue<Vector2>(); }

    #endregion
}