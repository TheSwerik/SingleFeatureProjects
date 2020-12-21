using Cinemachine;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class SizeCamera : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] [Range(0.0001f, 10f)] private float zoom = 3.25f;

    private void Start()
    {
        var virtualCamera = GetComponent<CinemachineVirtualCamera>();
        virtualCamera.m_Lens.OrthographicSize = tilemap.localBounds.size.y / zoom;
        Destroy(this);
    }
}