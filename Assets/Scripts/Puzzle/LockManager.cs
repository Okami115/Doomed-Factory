using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockManager : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject msg;
    [SerializeField] private Lock_PuzzleManager lockPuzzle;
    [SerializeField] private PlayerInputsReader _inputsReader;
    private bool isPlayerInRange;

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
        if (isPlayerInRange)
            lockPuzzle.InitPuzzle();
    }

    public void ReadyToInteract(bool ans)
    {
        isPlayerInRange = ans;
    }

    public GameObject GetMsg()
    {
        return msg;
    }
}