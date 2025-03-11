using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Game Pause SO")]
public class GamePauseSO : ScriptableObject
{
    public bool isPause = false;
    public bool isPlayerInRange = false;
    public bool isPlayPuzzle = false;

    public void SetPause()
    {
        isPause = !isPause;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
    }
    
    public void SetPlayPuzzle()
    {
        isPlayPuzzle = !isPlayPuzzle;
    }

    public void auxSceneController()
    {
        SceneManager.LoadScene(0);
        AkSoundEngine.StopAll();
        UnityEngine.Cursor.lockState = CursorLockMode.Confined;
    }
}
