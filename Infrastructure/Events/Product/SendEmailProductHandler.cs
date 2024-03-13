using Domain._Shared.Events;
using Domain.Product.Events.ProductCreated.Handlers;
using ProductEntity = Domain.Product.Entity.Product;

namespace Infrastructure.Events.Product
{
    public sealed class SendEmailProductHandler : ISendEmailProductHandler
    {
        public void Handle<ProductEntity>(IEvent<ProductEntity> eventData)
        {
            // Alguma rotina de enviar e-mail.
            Task.CompletedTask.Wait();
        }
    }
}
