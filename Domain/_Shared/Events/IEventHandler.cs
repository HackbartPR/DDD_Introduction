namespace Domain._Shared.Events
{
    public interface IEventHandler<T>
    {
        void Handle(IEvent<T> eventData);
    }
}
