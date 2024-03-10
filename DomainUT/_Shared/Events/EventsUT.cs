using Domain._Shared.Events;
using Domain.Product.Events.ProductCreated.Handlers;
using ProductEntity = Domain.Product.Entity.Product;

namespace DomainUT._Shared.Events
{
    public class EventsUT
    {
        [Fact]
        public void Register_Event()
        {
            // Arrange
            IEventHandler<ProductEntity> eventHandler = new SendEmailProductHandler();
            IEventDispatcher dispatcher = new EventDispatcher();

            // Act
            dispatcher.Register<ProductEntity>(eventName, eventHandler);

            dispatcher.GetEventHandlers(eventName);
            // Assert
        }
    }
}
