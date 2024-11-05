using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class SoundTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent _unityEvent;

    private void OnTriggerEnter(Collider other)
    {
        _unityEvent?.Invoke();
    }
}