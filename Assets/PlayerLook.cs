using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Transform _shoulderTarget;
    [SerializeField] private Transform _headTarget;
    [SerializeField] private Transform _cameraRotationTarget;
    [Range(0,1)]
    [SerializeField] private float _lookSensitivity = 1f;
    [Range(0,60)]
    [SerializeField] private float _maxLookRotationX = 90f;
    private Vector2 _lookRotationVector;
    private Vector2 _lookRotationY;
    private bool _isLooking;
    private bool _lookLock;

    internal void StartLook(Vector2 inputAxis)
    {
        _lookRotationVector.x += -inputAxis.y * _lookSensitivity;
        _lookRotationVector.y += inputAxis.x * _lookSensitivity;
        LimitLookRotation();
        _isLooking = true;
    }
    private void LimitLookRotation()
    {
        if (_lookRotationVector.x > _maxLookRotationX)
        {
            _lookRotationVector.x = _maxLookRotationX;
        }
        if (_lookRotationVector.x < -_maxLookRotationX)
        {
            _lookRotationVector.x = -_maxLookRotationX;
        }
    }
    private void FixedUpdate()
    {
        Look();
    }
    private void Look()
    {
        if(_isLooking && !_lookLock)
        {
            _headTarget.rotation = Quaternion.Euler(_lookRotationVector);
            _shoulderTarget.rotation = Quaternion.Euler(_lookRotationVector);
            _cameraRotationTarget.rotation = Quaternion.Euler(GetLookRotationY());
        }
    }
    private Vector2 GetLookRotationY()
    {
        //Essa forma de atribui��o de rota��o � otimizada pois n�o deixa lixo na mem�ria ram;
        //Por�m essa forma n�o h� muita seguran�a de que ir� funcionar sempre;
        //Em caso de problemas na c�mera troque a linha abaixo por um c�digo que iguale a rota��o
        //do _lookRotationY ao do _shoulderTarget
        _lookRotationY.y = _lookRotationVector.y;
        _lookRotationY.x = 0;
        return _lookRotationY;
    }
    internal void StopLook()
    {
        _isLooking = false;
    }
    internal void LockLook()
    {
        _lookLock = true;
    }
    internal void ReleaseLook()
    {
        _lookLock = false;
    }
}
