using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private CameraManagerChannelSO _cameraManagerChannel;
    [SerializeField] private CinemachineVirtualCamera _shoulderCamera;
    [SerializeField] private CinemachineVirtualCamera _interactionCamera;
    private CinemachineVirtualCamera _activeCamera;

    private void Awake()
    {
        _cameraManagerChannel.OnShoulderCamera += ShoulderCamera;
        _cameraManagerChannel.OnInteractionCamera += InteractionCamera;
    }
    private void ShoulderCamera()
    {
        if(_activeCamera != null)
        {
            _activeCamera.Priority = 0;
        }
        if (_shoulderCamera.Priority == 0)
        {
            _shoulderCamera.Priority = 1;
        }
        _activeCamera = _shoulderCamera;
    }

    private void InteractionCamera(Transform lookTarget)
    {
        if (_activeCamera != null)
        {
            _activeCamera.Priority = 0;
        }
        _interactionCamera.LookAt = lookTarget;
        _interactionCamera.Follow = lookTarget;
        if (_interactionCamera.Priority == 0)
        {
            _interactionCamera.Priority = 1;
        }
        _activeCamera = _interactionCamera;
    }
}
