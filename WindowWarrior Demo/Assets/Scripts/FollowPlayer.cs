using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private RectTransform canvas;
    private Camera _mainCamera;
    private RectTransform _rectTransform;

    private void Awake()
    {
        _mainCamera = Camera.main;
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        var viewportPoint = _mainCamera.WorldToViewportPoint(player.position);
        var canvasSizeDelta = canvas.sizeDelta;
        var newPosition = new Vector2(viewportPoint.x * canvasSizeDelta.x - canvasSizeDelta.x / 2,
                                      viewportPoint.y * canvasSizeDelta.y - canvasSizeDelta.y / 2);
        _rectTransform.anchoredPosition = newPosition;
    }
}