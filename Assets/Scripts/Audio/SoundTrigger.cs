using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class SoundTrigger : MonoBehaviour
{
    [SerializeField] private bool _isOneShot;
    [SerializeField] private bool _isTriggerWhitSound;
    [SerializeField] private bool _useOtherObject;
    [SerializeField] private string _triggerSoundName;
    [SerializeField] private GameObject _triggerGO;
    [SerializeField] private UnityEvent _unityEvent;

    private void OnEnable()
    {
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isTriggerWhitSound)
        {
            if (!_useOtherObject)
                AkSoundEngine.PostEvent(_triggerSoundName, gameObject);
            else
                AkSoundEngine.PostEvent(_triggerSoundName, _triggerGO);
            
            _unityEvent?.Invoke();
        }
        else
            _unityEvent?.Invoke();

        if (_isOneShot)
            gameObject.SetActive(false);
    }
}