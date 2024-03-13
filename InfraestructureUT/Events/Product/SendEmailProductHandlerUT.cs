using Domain._Shared.Entity;
using Domain._Shared.Events;
using Infrastructure.Events.Product;
using ProductEntity = Domain.Product.Entity.Product;

namespace InfraestructureUT.Events.Product
{
    public class SendEmailProductHandlerUT
    {
        [Fact]
        public void Register_Event()
        {
            // Arrange
            IEventHandler eventHandler = new SendEmailProductHandler();
            IEventDispatcher dispatcher = new EventDispatcher();

            // Act
            dispatcher.Register<ProductEntity>(Constants.Events.ProductCreated, eventHandler);
            var result = dispatcher.HasRegistered(Constants.Events.ProductCreated);

            // Assert
            Assert.True(result);
        }
    }
}
