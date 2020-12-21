using UnityEngine;

[RequireComponent(typeof(Controls))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    [SerializeField] private RectTransform mask;
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

        //TODO
        Debug.Log((Vector2) mask.position);
        Debug.Log(mask.anchoredPosition);
        Debug.Log((Vector2) mask.localPosition);
        Debug.Log((Vector2) Camera.main.WorldToScreenPoint(transform.position));
        Debug.Log((Vector2) Camera.main.WorldToViewportPoint(transform.position));
        // mask.anchoredPosition = Camera.main.WorldToScreenPoint(transform.position);
    }
}