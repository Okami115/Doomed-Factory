using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Elec_PuzzleManager : MonoBehaviour
{
    public static Elec_PuzzleManager Instance { get; private set; }
    [SerializeField] private int maxEnergyRequired = 10;
    [SerializeField] private int currentEnergy = 0;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void AddEnergy(int energy)
    {
        currentEnergy += energy;
        CheckEnergy();
        Debug.Log("currentEnergy + " + currentEnergy);
    }

    public void CheckEnergy()
    {
        if (currentEnergy == maxEnergyRequired)
        {
            Debug.Log("Elec_PuzzleManager.CheckEnergy");
        }
    }
}