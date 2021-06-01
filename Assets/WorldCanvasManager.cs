using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCanvasManager : MonoBehaviour
{
    [SerializeField] private WorldCanvasChannelSO _worldCanvasChannel;
    [SerializeField] private GameObject _interactionButtonImage;
    private void Awake()
    {
        _worldCanvasChannel.OnShowInteractionUI += ShowInteractionUI;
        _worldCanvasChannel.OnHideInteractionUI += HideInteractionUI;
    }
    private void ShowInteractionUI(Vector3 position)
    {
        _interactionButtonImage.transform.position = position;
        _interactionButtonImage.SetActive(true);
    }
    private void HideInteractionUI()
    {
        _interactionButtonImage.SetActive(false);
    }
}
