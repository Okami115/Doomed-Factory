using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockManager : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject msg;
    [SerializeField] private Lock_PuzzleManager lockPuzzle;
    [SerializeField] private PlayerInputsReader _inputsReader;
    [SerializeField] private GamePauseSO gamePause;

    private void Awake()
    {
        _inputsReader.OnPlayerInteract += InputsReaderOnOnPlayerInteract;
        lockPuzzle.OnPuzzleComplete += () => {gameObject.SetActive(false); };
    }

    private void OnDisable()
    {
        _inputsReader.OnPlayerInteract -= InputsReaderOnOnPlayerInteract;
    }

    private void InputsReaderOnOnPlayerInteract()
    {
        if (gamePause.isPlayerInRange)
            lockPuzzle.InitPuzzle();
    }

    public void ReadyToInteract(bool ans)
    {
        gamePause.isPlayerInRange = ans;
    }

    public GameObject GetMsg()
    {
        return msg;
    }
}