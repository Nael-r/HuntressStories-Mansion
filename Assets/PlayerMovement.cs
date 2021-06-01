using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStamina))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private PlayerStamina _stamina;
    [SerializeField] private Transform _cameraRotationTarget;
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _walkingSpeed = 2f;
    [SerializeField] private float _runningSpeed = 4f;
    [SerializeField] private float _runningStaminaCost = 8f;
    private float _maxSpeed;
    private Vector2 _inputVector;
    private Vector3 _movementDirection;
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
        _inputVector.x = inputAxis.x;
        _inputVector.y = inputAxis.y;
        _isMoving = true;
    }
    private void Update()
    {
        Run();
    }
    private void FixedUpdate()
    {
        AddMovementForce();
    }
    private void AddMovementForce()
    {
        if (!_isMoving)
        {
            return;
        }
        if (_rigidbody.velocity.magnitude < _maxSpeed)
        {
            _rigidbody.AddForce(_inputVector.y * _cameraRotationTarget.forward * _moveSpeed, ForceMode.Force);
            _rigidbody.AddForce(_inputVector.x * _cameraRotationTarget.right * _moveSpeed, ForceMode.Force);
        }
    }
    private Vector3 GetMovementVectorXZ()
    {
        _movementDirection.x = _cameraRotationTarget.transform.forward.x;
        _movementDirection.y = transform.position.y;
        _movementDirection.z = _cameraRotationTarget.transform.forward.z;
        return _movementDirection.normalized;
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
        _inputVector = Vector2.zero;
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
