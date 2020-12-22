using UnityEngine;

[RequireComponent(typeof(Controls))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    private Rigidbody2D _body;
    private Controls _controls;

    private void Awake()
    {
        _controls = GetComponent<Controls>();
        _body = GetComponentInChildren<Rigidbody2D>();
    }

    private void Update() { Move(_controls.GetMoveDirection()); }

    private void Move(Vector2 direction)
    {
        _body.velocity = new Vector2(Mathf.Round(direction.x) * speed, _body.velocity.y);
    }
}