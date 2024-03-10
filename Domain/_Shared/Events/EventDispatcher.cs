namespace Domain._Shared.Events
{
    public class EventDispatcher : IEventDispatcher
    {
        public void Notify<T>(IEvent<T> eventData)
        {
            throw new NotImplementedException();
        }

        public void Register<T>(string eventName, IEventHandler<T> handler)
        {
            throw new NotImplementedException();
        }

        public void Unregister<T>(string eventName, IEventHandler<T> handler)
        {
            throw new NotImplementedException();
        }

        public void UnregisterAll()
        {
            throw new NotImplementedException();
        }
    }
}
