using UnityEngine;

[RequireComponent(typeof(Controls))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    [SerializeField] private RectTransform canvas;
    [SerializeField] private RectTransform mask;
    [SerializeField] private Camera renderCamera;
    private Rigidbody2D _body;
    private Controls _controls;
    private Camera _mainCamera;

    private void Awake()
    {
        _controls = GetComponent<Controls>();
        _body = GetComponentInChildren<Rigidbody2D>();
        _mainCamera = Camera.main;
    }

    private void Update() { Move(_controls.GetMoveDirection()); }

    private void Move(Vector2 direction)
    {
        _body.velocity = new Vector2(Mathf.Round(direction.x) * speed, _body.velocity.y);

        var viewportPoint = _mainCamera.WorldToViewportPoint(transform.position);
        var canvasSizeDelta = canvas.sizeDelta;
        var newPos = new Vector2(viewportPoint.x * canvasSizeDelta.x - canvasSizeDelta.x / 2,
                                 viewportPoint.y * canvasSizeDelta.y - canvasSizeDelta.y / 2);
        mask.anchoredPosition = newPos;
    }
}