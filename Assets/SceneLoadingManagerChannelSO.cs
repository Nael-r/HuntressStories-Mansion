using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Scene Loading Manager", menuName = "Event Channels/Scene Loading Manager")]
public class SceneLoadingManagerChannelSO : ScriptableObject
{
    internal UnityAction OnShowContinueText;
    internal void ShowContinueText()
    {
        if (OnShowContinueText == null)
        {
            Debug.LogWarning("ShowContinueText has no listeners");
        }
        else
        {
            OnShowContinueText.Invoke();
        }
    }
    internal UnityAction OnContinue;
    internal void Continue()
    {
        if (OnContinue == null)
        {
            Debug.LogWarning("AllowSceneActivation has no listeners");
        }
        else
        {
            OnContinue.Invoke();
        }
    }
}