namespace Domain._Shared.Events
{
    public class EventDispatcher : IEventDispatcher
    {
        public Dictionary<string, IList<IEventHandler>> _eventHandler = new();

        public Dictionary<string, IList<IEventHandler>> GetEventHandlers() 
        { 
            return _eventHandler; 
        }

        public bool HasRegistered(string eventName)
        {
            return _eventHandler.ContainsKey(eventName);
        }

        public void Notify<T>(IEvent<T> eventData)
        {
            throw new NotImplementedException();
        }

        public void Register<T>(string eventName, IEventHandler handler)
        {
            if (! HasRegistered(eventName))
                _eventHandler[eventName] = new List<IEventHandler>();

            _eventHandler[eventName].Add(handler);
        }

        public void Unregister<T>(string eventName, IEventHandler handler)
        {
            throw new NotImplementedException();
        }

        public void UnregisterAll()
        {
            throw new NotImplementedException();
        }
    }
}
