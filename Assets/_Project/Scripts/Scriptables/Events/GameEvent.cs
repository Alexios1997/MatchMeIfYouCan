using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEvent<T> : ScriptableObject
{
    readonly List<IGameEventListener<T>> _listeners = new();

    public void Raise(T data)
    {
        // iterate through listeners
        // Backwards because they could DeRegister
        // themselves or be destroyed
        // It provides us some kind of protection
        for (var i = _listeners.Count - 1; i >= 0; i--)
        {
            _listeners[i].OnEventRaised(data);
        }
    }
    
    public void RegisterListener(IGameEventListener<T> listener) => _listeners.Add(listener);
    public void UnregisterListener(IGameEventListener<T> listener) => _listeners.Remove(listener);
}

// Null Programming pattern
// In case we dont want any kind of Generic Type
[CreateAssetMenu(menuName = "Scriptables/Events/Game Event")]
public class GameEvent : GameEvent<Unit>
{
    public void Raise() => Raise(new Unit());
}

public struct Unit
{
    public static Unit Default => default;
}
