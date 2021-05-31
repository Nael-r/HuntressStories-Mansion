using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Event Channels/ World Canvas",fileName = "World Canvas Manager")]
public class WorldCanvasChannelSO : ScriptableObject
{

    internal UnityAction<Transform> OnSendUI;

    internal void SendUI(Transform ui)
    {
        if(OnSendUI != null)
        {
            OnSendUI.Invoke(ui);
        }
        else
        {
            Debug.Log("SetParent has no listeners");
        }
    }
}
