using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Lock_PuzzleManager : MonoBehaviour
{
    [SerializeField] private PlayerMovementNavMesh playerMovementNav;
    [SerializeField] private GameObject playerLight;
    [SerializeField] private GameObject hand;
    [SerializeField] private GameObject UI;
    [SerializeField] private GameObject Lock;
    [SerializeField] private GameObject firstWheel;
    [SerializeField] private GameObject secondWheel;
    [SerializeField] private GameObject thirdWheel;
    [SerializeField] private Door DoorToOpen;
    [SerializeField] private LockConvination _lockConvination;
    [SerializeField] private LockConvination selectedConvination;
    public bool isPuzzleActive = false;
    private Vector3 newRot = Vector3.zero;
    public Action OnPuzzleComplete;
    [SerializeField] private GamePauseSO gamePauseSO;

    private void Awake()
    {
        selectedConvination.firstNumber = 1;
        selectedConvination.secondNumber = 1;
        selectedConvination.thirdNumber = 1;
    }

    public void InitPuzzle()
    {
        Cursor.lockState = CursorLockMode.Confined;
        hand.SetActive(false);
        playerMovementNav.CanMove = false;
        gamePauseSO.isPlayPuzzle = true;
        UI.SetActive(true);
        Lock.SetActive(true);
        playerLight.SetActive(false);
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerMovementNav.CanMove = true;
        UI.SetActive(false);
        Lock.SetActive(false);
        playerLight.SetActive(true);
    }

    public void UpWheel(int wheelNumber)
    {
        switch (wheelNumber)
        {
            case 1:
                selectedConvination.firstNumber++;
                
                if (selectedConvination.firstNumber > 9)
                    selectedConvination.firstNumber = 1;
                
                firstWheel.transform.localRotation = Quaternion.Euler(GetWheelRotation(selectedConvination.firstNumber));
                break;
            case 2:
                selectedConvination.secondNumber++;
                
                if (selectedConvination.secondNumber > 9)
                    selectedConvination.secondNumber = 1;
                
                secondWheel.transform.localRotation = Quaternion.Euler(GetWheelRotation(selectedConvination.secondNumber));
                break;
            case 3:
                selectedConvination.thirdNumber++;
                
                if (selectedConvination.thirdNumber > 9)
                    selectedConvination.thirdNumber = 1;
                
                thirdWheel.transform.localRotation = Quaternion.Euler(GetWheelRotation(selectedConvination.thirdNumber));
                break;
        }
    }

    public void DownWheel(int wheelNumber)
    {
        switch (wheelNumber)
        {
            case 1:
                selectedConvination.firstNumber--;
                
                if (selectedConvination.firstNumber < 1)
                    selectedConvination.firstNumber = 9;
                
                firstWheel.transform.localRotation = Quaternion.Euler(GetWheelRotation(selectedConvination.firstNumber));
                break;
            case 2:
                selectedConvination.secondNumber--;
                
                if (selectedConvination.secondNumber < 1)
                    selectedConvination.secondNumber = 9;
                
                secondWheel.transform.localRotation = Quaternion.Euler(GetWheelRotation(selectedConvination.secondNumber));
                break;
            case 3:
                selectedConvination.thirdNumber--;
                
                if (selectedConvination.thirdNumber < 1)
                    selectedConvination.thirdNumber = 9;
                
                thirdWheel.transform.localRotation = Quaternion.Euler(GetWheelRotation(selectedConvination.thirdNumber));
                break;
        }
    }

    public Vector3 GetWheelRotation(int currentWheelNumber)
    {
        Vector3 rot = Vector3.zero;

        switch (currentWheelNumber)
        {
            case 1:
                rot.x = 0.0f;
                break;
            case 2:
                rot.x = 40.0f;
                break;
            case 3:
                rot.x = 80.0f;
                break;
            case 4:
                rot.x = 120.0f;
                break;
            case 5:
                rot.x = 160.0f;
                break;
            case 6:
                rot.x = 200.0f;
                break;
            case 7:
                rot.x = 240.0f;
                break;
            case 8:
                rot.x = 280.0f;
                break;
            case 9:
                rot.x = 320.0f;
                break;
        }
        
        return rot;
    }

    private void Update()
    {
        if (selectedConvination == _lockConvination)
            OnPuzzleCompleation();
    }

    public void OnPuzzleCompleation()
    {
        gameObject.SetActive(false);
        DoorToOpen.OpenDoorWhitPuzzle();
        isPuzzleActive = false;
        gamePauseSO.isPlayPuzzle = false;
        OnPuzzleComplete.Invoke();
        
    }

    private IEnumerator TurnWheel()
    {
        yield return null;
    }

    [Serializable]
    public struct LockConvination
    {
        public int firstNumber;
        public int secondNumber;
        public int thirdNumber;

        public static bool operator ==(LockConvination a, LockConvination b)
        {
            if (a.firstNumber == b.firstNumber && a.secondNumber == b.secondNumber && a.thirdNumber == b.thirdNumber)
                return true;
            else
                return false;
        }

        public static bool operator !=(LockConvination a, LockConvination b)
        {
            return !(a == b);
        }
    }
}