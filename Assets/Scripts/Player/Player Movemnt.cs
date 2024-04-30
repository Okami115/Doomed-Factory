using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputsRead : MonoBehaviour
{
    public static event Action<Vector3> Moving;
    public void OnMove(InputValue input)
    {
        Moving?.Invoke(input.Get<Vector3>());
    }
}
