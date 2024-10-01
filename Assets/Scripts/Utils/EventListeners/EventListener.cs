using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class EventListener<EventType> : MonoBehaviour
{
    [SerializeField] private EventChannel<EventType> _eventChannel;
    [SerializeField] private UnityEvent<EventType> _unityEvent;

    protected void Awake() => _eventChannel.Register(this);
    protected void OnDestroy() => _eventChannel.DeRegister(this);

    public void Rise(EventType value)
    {
        _unityEvent?.Invoke(value);
    }
}

public class EventListener : EventListener<Empty>
{
    
}