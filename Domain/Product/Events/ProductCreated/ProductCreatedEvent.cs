using Domain._Shared.Events;
using ProductEntity = Domain.Product.Entity.Product;

namespace Domain.Product.Events.ProductCreated
{
    public sealed class ProductCreatedEvent : IEvent<ProductEntity>
    {
        public DateTime dateTimeOccurred { get ; set ; }
        public ProductEntity eventData { get ; set ; }
    }
}
