using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Camera Manager Channel", menuName = "Event Channels/Camera Manager")]
public class CameraManagerChannelSO : ScriptableObject
{
    internal UnityAction OnShoulderCamera;
    internal UnityAction<Transform> OnInteractionCamera;

    internal void ShoulderCamera()
    {
        if (OnShoulderCamera != null)
        {
            OnShoulderCamera.Invoke();
        }
        else
        {
            Debug.Log("ShoulderCamera has no listeners");
        }
    }

    internal void InteractionCamera(Transform lookTarget)
    {
        if (OnInteractionCamera != null)
        {
            OnInteractionCamera.Invoke(lookTarget);
        }
        else
        {
            Debug.Log("InteractionCamera has no listeners");
        }
    }
}
