namespace Domain._Shared.Events
{
    public interface IEvent<T>
    {
        DateTime dateTimeOccurred { get; set; }

        T eventData { get; set; }
    }
}
