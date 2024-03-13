namespace Domain._Shared.Events
{
    public interface IEventHandler
    {
        void Handle<T>(IEvent<T> eventData);
    }
}
