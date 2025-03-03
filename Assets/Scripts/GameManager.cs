using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GamePauseSO gamePauseSO;
    void Start()
    {
        gamePauseSO.isPause = false;
        gamePauseSO.isPlayerInRange = false;
        gamePauseSO.isPlayPuzzle = false;
    }
}
