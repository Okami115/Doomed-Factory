using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class SoundTrigger : MonoBehaviour
{
    [SerializeField] private bool _isOneShot;
    [SerializeField] private bool _isTriggerWhitSound;
    [SerializeField] private string _triggerSoundName;
    [SerializeField] private UnityEvent _unityEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (_isTriggerWhitSound)
        {
            AkSoundEngine.PostEvent(_triggerSoundName, gameObject);
            _unityEvent?.Invoke();
        }
        else
            _unityEvent?.Invoke();

        if (_isOneShot)
            Destroy(gameObject);
    }
}