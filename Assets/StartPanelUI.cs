using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanelUI : MonoBehaviour
{
    [SerializeField] private MainPanelUI _mainMenuPanel;
    [SerializeField] private GameManagerChannelSO _gameManagerChannelSO;
    public void OnOk()
    {
        _gameManagerChannelSO.StartGame();
    }

    public void OnBack()
    {
        _mainMenuPanel.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
