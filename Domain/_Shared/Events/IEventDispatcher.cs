namespace Domain._Shared.Events
{
    public interface IEventDispatcher
    {
        void Notify<T>(IEvent<T> eventData);

        void Register(string eventName, IEventHandler handler);

        void Unregister(string eventName, IEventHandler handler);

        void UnregisterAll();

        bool HasRegistered(string eventName, IEventHandler handler);
    }
}
