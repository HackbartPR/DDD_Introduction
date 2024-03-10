using Domain._Shared.Events;
using ProductEntity = Domain.Product.Entity.Product;

namespace Domain.Product.Events.ProductCreated.Handlers
{
    public interface ISendEmailProductHandler : IEventHandler<ProductEntity>
    {
    }
}
