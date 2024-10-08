using UnityEngine;

public class Circuit_breaker : MonoBehaviour,IInteractable
{
    private static readonly int BreakInteract = Animator.StringToHash("BreakInteract");
    [SerializeField] private Light _bulbLight;
    [SerializeField] private Animator _breakerAnimator;
    public int BreakerIndex;
    public int BreakerValue;

    public void ReadyToInteract(bool ans)
    {
        Elec_PuzzleManager.Instance.AddEnergy(BreakerValue);
        _breakerAnimator.SetTrigger(BreakInteract);
    }
}
