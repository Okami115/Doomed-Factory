using System;
using UnityEngine;

public class Circuit_breaker : MonoBehaviour,IInteractable
{
    private static readonly int BreakInteract = Animator.StringToHash("BreakInteract");
    [SerializeField] private Light _bulbLight;
    [SerializeField] private Animator _breakerAnimator;
    private PlayerInputsReader _playerInputsReader;
    public int BreakerValue;
    private bool isPlayerInRange;
    private bool isBreakerActive;

    private void OnEnable()
    {
        _playerInputsReader = Elec_PuzzleManager.Instance._playerInputsReader;
        _playerInputsReader.OnPlayerInteract += OnPlayerInteract;
    }

    private void OnDisable()
    {
        _playerInputsReader.OnPlayerInteract -= OnPlayerInteract;
    }

    private void OnPlayerInteract()
    {
        if (Elec_PuzzleManager.Instance.isPuzzleActive)
        {
            if (isPlayerInRange)
            {
                if (isBreakerActive)
                {
                    Elec_PuzzleManager.Instance.AddEnergy(-BreakerValue);
                    isBreakerActive = false;
                    _bulbLight.color = Color.red;
                }
                else
                {
                    Elec_PuzzleManager.Instance.AddEnergy(BreakerValue);
                    isBreakerActive = true;
                    _bulbLight.color = Color.green;
                }
                _breakerAnimator.SetTrigger(BreakInteract);
            }
        }
    }

    public void ReadyToInteract(bool ans)
    {
        isPlayerInRange = ans;
        
    }

    public void Update()
    {
        
    }
}
