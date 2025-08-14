using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public void StartGame()
    {
        EventBus.InvokeEvent(GameEvent.StartGame);
    }
    public void PauseGame()
    {
        EventBus.InvokeEvent(GameEvent.PauseGame);
    }
    public void ResumeGame()
    {
        EventBus.InvokeEvent(GameEvent.ResumeGame);
    }
    public void FinishGame()
    {
        EventBus.InvokeEvent(GameEvent.FinishGame);
    }
    public void RestartGame()
    {
        EventBus.InvokeEvent(GameEvent.ResumeGame);
    }
}
