using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour
{
    [SerializeField] private PlayerControllerChannelSO _playerControllerChannel;
    [SerializeField] private CameraManagerChannelSO _cameraManagerChannel;
    [SerializeField] private WorldCanvasChannelSO _worldCanvasChannel;
    [SerializeField] private Transform _interactionButtonPosition;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _worldCanvasChannel.ShowInteractionUI(_interactionButtonPosition.position);
            _playerControllerChannel.OnInteraction += Interaction;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _worldCanvasChannel.HideInteractionUI();
            _playerControllerChannel.OnInteraction -= Interaction;
        }
    }

    private void Interaction()
    {
        _playerControllerChannel.OnInteractionCancel += InteractionCancel;
        _cameraManagerChannel.InteractionCamera(transform);
        _playerControllerChannel.ActivateInteractionControls();
        _worldCanvasChannel.HideInteractionUI();
    }

    private void InteractionCancel()
    {
        _playerControllerChannel.OnInteractionCancel -= InteractionCancel;
        _cameraManagerChannel.ShoulderCamera();
        _playerControllerChannel.ActivatePlayingControls();
        _worldCanvasChannel.ShowInteractionUI(_interactionButtonPosition.position);
    }
}
