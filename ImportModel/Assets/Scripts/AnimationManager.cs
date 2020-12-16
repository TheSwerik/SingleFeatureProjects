using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationManager : MonoBehaviour
{
    private static readonly int SpeedPercent = Animator.StringToHash("SpeedPercent");
    [SerializeField] private float transitionDampTime = 0.1f;
    private Animator _animator;
    private Movement _movement;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _movement = GetComponentInParent<Movement>();
    }

    private void Update()
    {
        // Debug.Log(_movement.CurrentSpeedPercent + " and " + _movement.CurrentSpeed);
        _animator.SetFloat(SpeedPercent, _movement.CurrentSpeedPercent, transitionDampTime, Time.deltaTime);
    }
}