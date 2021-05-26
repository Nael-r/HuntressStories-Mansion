using UnityEngine;

public class ContinuePanelUI : MonoBehaviour
{
    [SerializeField] private MainPanelUI _mainMenuPanel;
    [SerializeField] private GameObject _savedGameContainer;
    [SerializeField] private GameObject _savedGameItemPrefab;
    private void OnEnable()
    {
        Debug.Log("Show saved games");
    }
    public void OnBack()
    {
        _mainMenuPanel.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
