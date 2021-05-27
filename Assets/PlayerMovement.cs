using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStamina))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private PlayerStamina _stamina;
    [SerializeField] private Transform _followTarget;
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _walkingSpeed = 2f;
    [SerializeField] private float _runningSpeed = 4f;
    [SerializeField] private float _runningStaminaCost = 8f;
    private float _maxSpeed;
    private Vector3 _movementVector;
    private bool _isMoving;
    private bool _isRunning;
    private void Awake()
    {
        if (_rigidbody == null)
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        if(_stamina == null)
        {
            _stamina = GetComponent<PlayerStamina>();
        }
    }
    private void Start()
    {
        _maxSpeed = _walkingSpeed;
    }
    internal void StartMoving(Vector2 inputAxis)
    {
        _movementVector.x = inputAxis.x;
        _movementVector.y = 0;
        _movementVector.z = inputAxis.y;
        _isMoving = true;
    }
    private void FixedUpdate()
    {
        AddMovementForce();
        Run();
    }
    private void AddMovementForce()
    {
        if (!_isMoving)
        {
            return;
        }
        if (_rigidbody.velocity.magnitude < _maxSpeed)
        {
            _rigidbody.AddForce(_movementVector.z * _followTarget.forward * _moveSpeed, ForceMode.Force);
            _rigidbody.AddForce(_movementVector.x * _followTarget.right * _moveSpeed, ForceMode.Force);
        }
        else //this is to ensure that theres is always change of direction, even when player is at max speed
        {
            _rigidbody.AddForce(_movementVector.z * _followTarget.forward * _moveSpeed / 10, ForceMode.Force);
            _rigidbody.AddForce(_movementVector.x * _followTarget.right * _moveSpeed / 10, ForceMode.Force);
        }
    }
    private void Run()
    {
        if (!_isMoving || !_isRunning)
        {
            return;
        }
        if (_stamina.IsThereEnoughStamina(_runningStaminaCost))
        {
            _stamina.ConsumeStamina(_runningStaminaCost);
        }
        else
        {
            StopRunning();
        }
    }
    internal void StopMoving()
    {
        _movementVector = Vector3.zero;
        _isMoving = false;
    }

    internal void StartRunning()
    {
        _maxSpeed = _runningSpeed;
        _isRunning = true;
    }

    internal void StopRunning()
    {
        _maxSpeed = _walkingSpeed;
        _isRunning = false;
    }
}
