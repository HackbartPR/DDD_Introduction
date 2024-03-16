namespace Domain._Shared.Events
{
    public interface IEvent<T>
    {
        DateTime DateTimeOccurred { get; }

        T EventData { get; }
    }
}
