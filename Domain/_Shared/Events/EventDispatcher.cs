namespace Domain._Shared.Events
{
    public class EventDispatcher : IEventDispatcher
    {
        public Dictionary<string, IList<IEventHandler>> _eventHandler = new();

        public Dictionary<string, IList<IEventHandler>> GetEventHandlers() 
        { 
            return _eventHandler; 
        }

        public bool HasRegistered(string eventName, IEventHandler handler)
        {
            if (!_eventHandler.ContainsKey(eventName)) 
                return false;

            return _eventHandler[eventName].Any(h => h.Equals(handler));
        }

        public void Notify<T>(IEvent<T> eventData)
        {
            throw new NotImplementedException();
        }

        public void Register(string eventName, IEventHandler handler)
        {
            if (! HasRegistered(eventName, handler))
                _eventHandler[eventName] = new List<IEventHandler>();

            _eventHandler[eventName].Add(handler);
        }

        public void Unregister(string eventName, IEventHandler handler)
        {
            if (HasRegistered(eventName, handler))
                _eventHandler[eventName].Remove(handler);
        }

        public void UnregisterAll()
        {
            _eventHandler.Clear();
        }
    }
}
