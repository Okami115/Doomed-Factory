using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputsReader : MonoBehaviour
{
    [SerializeField] private PlayerInput _input;
    public event Action<Vector3> OnPlayerMove;
    public event Action OnPlayerInteract;
    
    public void OnMove(InputValue input)
    {
        OnPlayerMove?.Invoke(input.Get<Vector3>());
        Debug.Log("OnPlayerMove");
    }

    public void OnInteract(InputValue input)
    {
        OnPlayerInteract?.Invoke();
    }
}
