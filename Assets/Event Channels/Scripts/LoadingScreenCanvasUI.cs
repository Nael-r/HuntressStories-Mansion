using UnityEngine;

public class LoadingScreenCanvasUI : MonoBehaviour
{
    [SerializeField] private SceneLoadingManagerChannelSO _sceneLoadingManager;
    [SerializeField] private GameObject _continueButton;

    private void Awake()
    {
        _sceneLoadingManager.OnShowContinueText += ShowContinueText;
    }

    internal void ShowContinueText()
    {
        _continueButton.gameObject.SetActive(true);
    }

    public void OnContinue()
    {
        _sceneLoadingManager.Continue();
        _continueButton.gameObject.SetActive(false);
    }


}
