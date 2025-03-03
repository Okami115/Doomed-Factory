using UnityEngine;

[CreateAssetMenu(menuName = "Game Pause SO")]
public class GamePauseSO : ScriptableObject
{
    public bool isPause = false;
    public bool isPlayerInRange = false;
    public bool isPlayPuzzle = false;

    public void SetPause()
    {
        isPause = !isPause;
    }
    
    public void SetPlayPuzzle()
    {
        isPlayPuzzle = !isPlayPuzzle;
    }
}
