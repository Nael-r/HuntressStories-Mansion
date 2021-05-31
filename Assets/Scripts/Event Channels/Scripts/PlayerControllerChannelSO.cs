using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Event Channels/Player Controller", fileName = "Player Controller Channel")]
public class PlayerControllerChannelSO : ScriptableObject
{
    internal UnityAction OnActivatePlayingControls;
    internal UnityAction OnActivateInteractionControls;
    internal UnityAction OnInteraction;
    internal UnityAction OnInteractionCancel;

    internal void ActivatePlayingControls()
    {
        if (OnActivatePlayingControls != null)
        {
            OnActivatePlayingControls.Invoke();
        }
        else
        {
            Debug.LogWarning("ActivatePlayingControls has no listeners");
        }
    }
    internal void ActivateInteractionControls()
    {
        if (OnActivateInteractionControls != null)
        {
            OnActivateInteractionControls.Invoke();
        }
        else
        {
            Debug.LogWarning("InteractionControls has no listeners");
        }
    }
    internal void Interact()
    {
        if(OnInteraction != null)
        {
            OnInteraction.Invoke();
        }
    }
    internal void InteractCancel()
    {
        if (OnInteractionCancel != null)
        {
            OnInteractionCancel.Invoke();
        }
    }
}
