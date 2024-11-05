using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class SoundTrigger : MonoBehaviour
{
    [SerializeField] private bool _isOneShot;
    [SerializeField] private UnityEvent _unityEvent;

    private void OnTriggerEnter(Collider other)
    {
        _unityEvent?.Invoke();

        if (_isOneShot)
            Destroy(gameObject);
    }
}