using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCanvasManager : MonoBehaviour
{
    [SerializeField] private WorldCanvasChannelSO _interactionCanvas;
    private void Awake()
    {
        _interactionCanvas.OnSendUI += ReceiveUI;
    }
    private void ReceiveUI(Transform ui)
    {
        ui.SetParent(transform);
    }
}
