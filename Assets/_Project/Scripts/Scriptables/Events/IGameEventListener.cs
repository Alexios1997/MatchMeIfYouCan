
// A simple interface for Game eVENT Listener 
// for all to implement the OnEventRaised
public interface IGameEventListener<T>
{
    void OnEventRaised(T data);
}

