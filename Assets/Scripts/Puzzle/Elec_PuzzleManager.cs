using System;
using System.Collections.Generic;
using UnityEngine;

public class Elec_PuzzleManager : MonoBehaviour
{
    public static Elec_PuzzleManager Instance { get; private set; }
    public bool isPuzzleActive = false;
    public PlayerInputsReader _playerInputsReader;
    public event Action OnpuzzleFinished;
    [SerializeField] private int maxEnergyRequired = 7;
    [SerializeField] private int currentEnergy = 0;
    [SerializeField] private List<Light> lights = new List<Light>();
    [SerializeField] private Door DoorToOpen;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        if (_playerInputsReader == null)
            _playerInputsReader = FindObjectOfType<PlayerInputsReader>();
        
        isPuzzleActive = true;
    }

    public void AddEnergy(int energy)
    {
        currentEnergy += energy;
        Debug.Log("currentEnergy : " + currentEnergy);
        CheckEnergy();
    }

    public void CheckEnergy()
    {
        if (currentEnergy == maxEnergyRequired)
        {
            OnPuzzleCompleation();
        }

        for (int i = 0; i < lights.Count; i++)
        {
            if (i < currentEnergy)
                lights[i].color = Color.green;
            else
                lights[i].color = Color.red;
        }
    }

    public void OnPuzzleCompleation()
    {
        DoorToOpen.OpenDoorWhitPuzzle();
        isPuzzleActive = false;
        OnpuzzleFinished?.Invoke();
    }
}