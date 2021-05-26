using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadingManager : MonoBehaviour
{
    [SerializeField] private SceneLoadingManagerChannelSO _myChannel;
    private bool _shouldContinue = false;
    private void Awake()
    {
        _myChannel.OnContinue += Continue;
    }
    internal void LoadWithoutLoadingScreen(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    internal void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneCoroutine(sceneName));
    }

    private IEnumerator LoadSceneCoroutine(string sceneName)
    {
        yield return LoadingScreen();
        yield return PlayScene(sceneName);
    }

    private IEnumerator LoadingScreen()
    {
        SceneManager.LoadScene("Loading Screen");
        yield return null;
    }

    private IEnumerator PlayScene(string sceneName)
    {
        _shouldContinue = false;
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        asyncOperation.allowSceneActivation = false;
        while (!asyncOperation.isDone)
        {
            if (asyncOperation.progress >= 0.9f)
            {
                _myChannel.ShowContinueText();
                if (_shouldContinue)
                {
                    asyncOperation.allowSceneActivation = true;
                }
            }
            yield return null;
        }
    }

    private void Continue()
    {
        _shouldContinue = true;
    }
}
