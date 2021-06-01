using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Event Channels/ World Canvas",fileName = "World Canvas Manager")]
public class WorldCanvasChannelSO : ScriptableObject
{

    internal UnityAction<Vector3> OnShowInteractionUI;
    internal UnityAction OnHideInteractionUI;

    internal void ShowInteractionUI(Vector3 position)
    {
        if(OnShowInteractionUI != null)
        {
            OnShowInteractionUI.Invoke(position);
        }
        else
        {
            Debug.Log("ShowInteractionUI has no listeners");
        }
    }

    internal void HideInteractionUI()
    {
        if (OnHideInteractionUI != null)
        {
            OnHideInteractionUI.Invoke();
        }
        else
        {
            Debug.Log("HideInteractionUI has no listeners");
        }
    }


}
