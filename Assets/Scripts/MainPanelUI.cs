using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPanelUI : MonoBehaviour
{
    [SerializeField] private StartPanelUI _startPanelUI;
    [SerializeField] private ContinuePanelUI _continuePanelUI;
    [SerializeField] private OptionsPanelUI _optionsPanelUI;
    public void OnStart()
    {
        _startPanelUI.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void OnContinue()
    {
        _continuePanelUI.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void OnOptions()
    {

    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
