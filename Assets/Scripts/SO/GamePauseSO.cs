using UnityEngine;

[CreateAssetMenu(menuName = "Game Pause SO")]
public class GamePauseSO : ScriptableObject
{
    public bool isPause = false;

    public void SetPause()
    {
        isPause = !isPause;
    }
}
