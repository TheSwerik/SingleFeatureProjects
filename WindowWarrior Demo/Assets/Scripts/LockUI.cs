using UnityEngine;

[ExecuteInEditMode]
public class LockUI : MonoBehaviour
{
    [SerializeField] private bool active = true;
    private Vector3 _position;
    private RectTransform _rectTransform;
    private Vector3 _scale;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _position = _rectTransform.position;
        _scale = _rectTransform.localScale;
    }

    private void Update()
    {
        if (!active)
        {
            _position = _rectTransform.position;
            _scale = _rectTransform.localScale;
            return;
        }

        _rectTransform.position = _position;
        _rectTransform.localScale = _scale;
    }
}