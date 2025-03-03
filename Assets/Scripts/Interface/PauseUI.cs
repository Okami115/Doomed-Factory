using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    [SerializeField] private GamePauseSO gamePauseSO;
    [SerializeField] private GameObject pauseUI;
    private void Start()
    {
        pauseUI.SetActive(false);
    }

    private void Update()
    {
        if (!gamePauseSO.isPlayPuzzle)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pauseUI.SetActive(!gamePauseSO.isPause);
                if(!gamePauseSO.isPause)
                    UnityEngine.Cursor.lockState = CursorLockMode.Confined;
                else
                    UnityEngine.Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
