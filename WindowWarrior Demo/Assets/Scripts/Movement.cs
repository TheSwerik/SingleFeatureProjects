using UnityEngine;

[RequireComponent(typeof(Controls))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    private Rigidbody2D _body;
    private Controls _controls;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _controls = GetComponent<Controls>();
        _body = GetComponentInChildren<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        var velocity = Move(_controls.GetMoveDirection());
        if (velocity.x != 0) Flip(velocity.x > 0);
    }

    private void Flip(bool right) { _spriteRenderer.flipX = !right; }

    private Vector2 Move(Vector2 direction)
    {
        return _body.velocity = new Vector2(Mathf.Round(direction.x) * speed, _body.velocity.y);
    }
}