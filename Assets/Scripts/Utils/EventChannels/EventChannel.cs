using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public readonly struct Empty { }

public abstract class EventChannel<ChannelType>: ScriptableObject
{
    private readonly HashSet<EventListener<ChannelType>> observers = new();

    public void Invoke(ChannelType value)
    {
        foreach (EventListener<ChannelType> observer in observers)
        {
            observer.Rise(value);
        }
    }

    /// <summary>
    /// Register an observer for the events
    /// </summary>
    /// <param name="observer"></param>
    public void Register(EventListener<ChannelType> observer) => observers.Add(observer);
    /// <summary>
    /// Remove an observer for the events
    /// </summary>
    /// <param name="observer"></param>
    public void DeRegister(EventListener<ChannelType> observer) => observers.Remove(observer);
}

[CreateAssetMenu(menuName = "Events/EventChannel")]
public class EventChannel : EventChannel<Empty>
{
    
}


