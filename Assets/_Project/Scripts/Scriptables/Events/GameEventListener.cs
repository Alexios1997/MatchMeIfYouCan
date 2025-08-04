using UnityEngine;
using UnityEngine.Events;

public class GameEventListener<T> : MonoBehaviour, IGameEventListener<T>
{
    [SerializeField] GameEvent<T> gameEvent;
    [SerializeField] UnityEvent<T> response;

    void OnEnable() => gameEvent.RegisterListener(this);
    void OnDisable() => gameEvent.UnregisterListener(this);
    
    public void OnEventRaised(T data) => response.Invoke(data);
}

public class GameEventListener: GameEventListener<Unit>
{
}