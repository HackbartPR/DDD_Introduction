namespace Domain._Shared.Events
{
    public interface IEventDispatcher
    {
        void Notify<T>(IEvent<T> eventData);

        void Register<T>(string eventName, IEventHandler handler);

        void Unregister<T>(string eventName, IEventHandler handler);

        void UnregisterAll();

        bool HasRegistered(string eventName);
    }
}
