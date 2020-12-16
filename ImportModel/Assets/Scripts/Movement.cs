using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Controls))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float gravity = 10f;
    [SerializeField] private Transform groundCheck;

    private CharacterController _controller;
    private Controls _controls;
    private int _groundCheckLayerMask;
    private bool _isGrounded;
    private Transform _mainCameraTransform;
    private Transform _transform;
    private Vector3 _velocity;

    public float CurrentSpeed => new Vector2(_controller.velocity.x, _controller.velocity.z).magnitude;
    public float CurrentSpeedPercent => CurrentSpeed / speed;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _controls = GetComponent<Controls>();
        _transform = transform;
        _groundCheckLayerMask = ~LayerMask.GetMask("Player");
        _mainCameraTransform = Camera.main!.transform;
    }

    private void Update()
    {
        _isGrounded = Physics.CheckSphere(groundCheck.position, groundCheck.localScale.x, _groundCheckLayerMask);
        Move(_controls.InputActions.Player.Move.ReadValue<Vector2>());
        Fall();
    }

    private void LateUpdate() { Rotate(); }

    private void Move(Vector2 direction)
    {
        var correctedDirection = _mainCameraTransform.right * direction.x + _mainCameraTransform.forward * direction.y;
        _controller.Move(correctedDirection * (speed * Time.deltaTime));
    }

    private void Rotate()
    {
        var direction = _mainCameraTransform.forward;
        _transform.rotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
    }

    private void Fall()
    {
        if (_isGrounded && _velocity.y < 0)
        {
            Debug.Log(1);
            _velocity = Vector3.down; // a little leeway so it really touches the ground
            return;
        }

        Debug.Log(2);

        _velocity.y -= gravity;
        _controller.Move(_velocity * Time.deltaTime);
    }
    private void OnDrawGizmos() { Gizmos.DrawWireSphere(groundCheck.position, groundCheck.localScale.x); }
}