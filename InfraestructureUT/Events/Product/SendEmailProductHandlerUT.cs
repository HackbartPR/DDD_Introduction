using Domain._Shared.Entity;
using Domain._Shared.Events;
using Domain.Product.Events.ProductCreated;
using Domain.Product.Events.ProductCreated.Handlers;
using Infrastructure.Events.Product;
using Moq;
using System;
using System.Net.Http.Headers;
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
            dispatcher.Register(Constants.Events.ProductCreated, eventHandler);
            var result = dispatcher.HasRegistered(Constants.Events.ProductCreated, eventHandler);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Unregister_Event()
        {
            // Arrange
            IEventHandler handler = new SendEmailProductHandler();
            IEventDispatcher dispatcher = new EventDispatcher();

            // Act & Assert
            dispatcher.Register(Constants.Events.ProductCreated, handler);
            Assert.True(dispatcher.HasRegistered(Constants.Events.ProductCreated, handler));

            dispatcher.Unregister(Constants.Events.ProductCreated, handler);
            Assert.False(dispatcher.HasRegistered(Constants.Events.ProductCreated, handler));
        }

        [Fact]
        public void UnregisterAll_Event()
        {
            // Arrange
            IEventHandler handler = new SendEmailProductHandler();
            IEventDispatcher dispatcher = new EventDispatcher();

            // Act & Assert
            dispatcher.Register(Constants.Events.ProductCreated, handler);
            Assert.True(dispatcher.HasRegistered(Constants.Events.ProductCreated, handler));

            dispatcher.UnregisterAll();
            Assert.False(dispatcher.HasRegistered(Constants.Events.ProductCreated, handler));
        }

        [Fact]
        public void Notify_Event()
        {
            // Arrange
            var handler = new Mock<ISendEmailProductHandler>();
            EventDispatcher dispatcher = new EventDispatcher();
            IEvent<ProductEntity> eventt = new ProductCreatedEvent(new ProductEntity(Guid.NewGuid(), "Produto 01", 10));

            // Act
            dispatcher.Register(Constants.Events.ProductCreated, handler.Object);
            dispatcher.Notify<ProductEntity>(eventt);
            
            // Assert
            Assert.True(dispatcher.HasRegistered(Constants.Events.ProductCreated, handler.Object));
            handler.Verify(h => h.Handle(eventt), Times.Once);
        }
    }
}
