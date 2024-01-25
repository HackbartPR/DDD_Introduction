using Domain.Checkout.Entity;
using Domain.Checkout.Services;

namespace DomainUT.Checkout.Services
{
    public class OrderServiceUT
    {
        [Fact]
        public void CalculateTotalValue_Successfuly()
        {
            // Arrange
            var item1 = new OrderItem(Guid.NewGuid(), "Item 1", 2, 10, Guid.NewGuid());
            var item2 = new OrderItem(Guid.NewGuid(), "Item 1", 3, 20, Guid.NewGuid());

            ICollection<OrderItem> items1 = new List<OrderItem>() { item1 };
            ICollection<OrderItem> items2 = new List<OrderItem>() { item2 };

            ICollection<Order> orders = new List<Order>()
            {
                new Order(Guid.NewGuid(), Guid.NewGuid(), 100, items1),
                new Order(Guid.NewGuid(), Guid.NewGuid(), 200, items2)
            };

            // Act
            var result = OrderService.CalculateTotalValue(orders);

            // Assert
            Assert.True(result == 80);
        }

        [Fact]
        public void CalculateTotalValue_EmptyOrderList_Returns_Zero()
        {
            // Arrange
            ICollection<Order> orders = new List<Order>();

            // Act
            var result = OrderService.CalculateTotalValue(orders);

            // Assert
            Assert.True(result == 0);
        }
    }
}
