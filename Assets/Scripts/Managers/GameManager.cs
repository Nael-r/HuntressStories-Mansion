using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SceneLoadingManager))]
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameManagerChannelSO _myChannel;
    [SerializeField] private SceneLoadingManager _sceneLoadingManager;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        _myChannel.OnStartGame += StartGame;
    }

    private void Start()
    {
        _sceneLoadingManager.LoadScene("Main Menu");
    }

    private void StartGame()
    {
        _sceneLoadingManager.LoadScene("Rasnov");
    }

    
}
