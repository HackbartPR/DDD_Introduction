using Domain._Shared.Events;
using ProductEntity = Domain.Product.Entity.Product;

namespace Domain.Product.Events.ProductCreated
{
    public sealed class ProductCreatedEvent : IEvent<ProductEntity>
    {
        public DateTime DateTimeOccurred { get; }
        public ProductEntity EventData { get; }

        public ProductCreatedEvent(ProductEntity eventData)
        {
            DateTimeOccurred = DateTime.UtcNow;
            EventData = eventData;
        }
    }
}
