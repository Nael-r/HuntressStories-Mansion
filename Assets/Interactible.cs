using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour
{
    [SerializeField] private PlayerControllerChannelSO _playerControllerChannel;
    [SerializeField] private CameraManagerChannelSO _cameraManagerChannel;
    [SerializeField] private WorldCanvasChannelSO _worldCanvasChannel;
    [SerializeField] private GameObject _interactionButtonImage;
    private void Start()
    {
        _worldCanvasChannel.SendUI(_interactionButtonImage.transform);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _interactionButtonImage.SetActive(true);
            _playerControllerChannel.OnInteraction += Interaction;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _interactionButtonImage.SetActive(false);
            _playerControllerChannel.OnInteraction -= Interaction;
        }
    }

    private void Interaction()
    {
        _playerControllerChannel.OnInteractionCancel += InteractionCancel;
        _cameraManagerChannel.InteractionCamera(transform);
        _playerControllerChannel.ActivateInteractionControls();
        _interactionButtonImage.SetActive(false);
    }

    private void InteractionCancel()
    {
        _playerControllerChannel.OnInteractionCancel -= InteractionCancel;
        _cameraManagerChannel.ShoulderCamera();
        _playerControllerChannel.ActivatePlayingControls();
        _interactionButtonImage.SetActive(true);
    }
}
