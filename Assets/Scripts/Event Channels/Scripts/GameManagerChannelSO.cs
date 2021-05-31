using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Game Manager Channel", menuName = "Event Channels/Game Manager")]
public class GameManagerChannelSO : ScriptableObject
{
    internal UnityAction OnStartGame;
    internal void StartGame()
    {
        if(OnStartGame == null)
        {
            Debug.LogWarning("StartGame has no listeners");
        }
        else
        {
            OnStartGame.Invoke();
        }
    }
}