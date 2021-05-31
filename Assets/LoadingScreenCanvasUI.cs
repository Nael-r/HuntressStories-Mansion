using UnityEngine;

public class LoadingScreenCanvasUI : MonoBehaviour
{
    [SerializeField] private SceneLoadingManagerChannelSO _sceneLoadingManager;
    [SerializeField] private TMPro.TMP_Text _continueText;
    private DefaultInputMap _defaultInputMap;

    private void Awake()
    {
        _sceneLoadingManager.OnShowContinueText += ShowContinueText;
        
    }

    internal void ShowContinueText()
    {
        _continueText.gameObject.SetActive(true);
        SubscribeButton();
        
    }

    private void SubscribeButton()
    {
        if (_defaultInputMap == null)
        {
            _defaultInputMap = new DefaultInputMap();
        }
        _defaultInputMap.Enable();
        _defaultInputMap.Player.Fire.started += ctx => OnContinue();
    }

    private void OnContinue()
    {
        _sceneLoadingManager.Continue();
        _continueText.gameObject.SetActive(false);
        _defaultInputMap.Disable();
    }


}
