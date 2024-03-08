using Domain._Shared.Repository;
using Domain.Checkout.Entity;
using InfraestructureUT.Database.EntityFramework.Settings;
using Infrastructure.Database.EntityFramework.Repository;
using Infrastructure.Repository._Shared;
using Infrastructure.Repository.Checkout;
using Infrastructure.Repository.Product;
using ProductEntity = Domain.Product.Entity.Product;


namespace InfraestructureUT.Repository.Checkout
{
    public class OrderRepositoryUT
    {
        private readonly IRepositoryORM repositoryORM;
        private readonly IBaseRepository<Order> orderRepository;
        private readonly IBaseRepository<ProductEntity> productRepository;

        public OrderRepositoryUT()
        {
            repositoryORM = new EntityFrameworkRepository(EFContextUT.GetContext());
            orderRepository = new OrderRepository(repositoryORM);
            productRepository = new ProductRepository(repositoryORM);
        }

        [Fact]
        public async Task Create_Successfuly()
        {
            // Arrange
            ProductEntity produto = new(Guid.NewGuid(), "Produto 01", 10, 20);
            await productRepository.CreateAsync(produto);

            ICollection<OrderItem> items = new List<OrderItem>
            {
                new(Guid.NewGuid(), "Item 01", 2, 10, produto.Id),
                new(Guid.NewGuid(), "Item 02", 1, 5, produto.Id)
            };

            Order order = new(Guid.NewGuid(), Guid.NewGuid(), 10, items);

            // Act
            await orderRepository.CreateAsync(order);
            Order? result = await orderRepository.FindAsync(order.Id);

            //Assert
            Assert.Equivalent(order, result);
        }

        [Fact]
        public async Task Update_Successfuly()
        {
            // Arrange
            ProductEntity produto = new(Guid.NewGuid(), "Produto 01", 10, 20);
            await productRepository.CreateAsync(produto);

            ICollection<OrderItem> items = new List<OrderItem>
            {
                new(Guid.NewGuid(), "Item 01", 2, 10, produto.Id),
                new(Guid.NewGuid(), "Item 02", 1, 5, produto.Id)
            };

            Order order = new(Guid.NewGuid(), Guid.NewGuid(), 10, items);

            // Act
            await orderRepository.CreateAsync(order);
            Order? result = await orderRepository.FindAsync(order.Id);
            Assert.Equivalent(order, result);

            repositoryORM.ClearChangeTracker();

            result?.AddItem(new OrderItem(Guid.NewGuid(), "Item 03", 1, 10, produto.Id));
            await orderRepository.UpdateAsync(order);
            Order? updateResult = await orderRepository.FindAsync(order.Id);

            // Assert
            Assert.Equivalent(updateResult, result);
        }
    }
}
