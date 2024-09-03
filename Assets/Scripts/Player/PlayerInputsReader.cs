using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputsReader : MonoBehaviour
{
    [SerializeField] private PlayerInput _input;
    public event Action<Vector3> OnPlayerMove;
    public event Action OnPlayerOpenPhone;
    public event Action OnPlayerInteract;
    public event Action OnPlayerExitApp;
    public event Action OnPlayerOpenApp;
    public event Action<float> OnScroll;
    
    public void OnMove(InputValue input)
    {
        OnPlayerMove?.Invoke(input.Get<Vector3>());
        Debug.Log("OnPlayerMove");
    }

    public void OnInteract(InputValue input)
    {
        OnPlayerInteract?.Invoke();
    }

    public void OnOpenApp(InputValue input)
    {
        OnPlayerOpenApp?.Invoke();
    }

    public void OnExitApp(InputValue input)
    {
        OnPlayerExitApp?.Invoke();
    }

    public void OnMouseScroll(InputValue input)
    {
        OnScroll?.Invoke(input.Get<float>());
    }

    public void OnOpenPhone()
    {
        OnPlayerOpenPhone?.Invoke();
    }
}
