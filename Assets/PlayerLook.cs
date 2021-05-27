using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Transform _followTarget;
    [SerializeField] private float _lookSensitivity = 10f;
    private Vector2 _lookRotationVector;
    private bool _isLooking;

    internal void StartLook(Vector2 inputAxis)
    {
        _lookRotationVector.x += -inputAxis.y;
        _lookRotationVector.y += inputAxis.x;
        _isLooking = true;
    }

    private void FixedUpdate()
    {
        Look();
    }

    private void Look()
    {
        if(_isLooking)
        {
            _followTarget.rotation = Quaternion.Euler(_lookRotationVector * _lookSensitivity);
        }
    }

    internal void StopLook()
    {
        _isLooking = false;
    }
    internal void LockLook()
    {

    }
}
