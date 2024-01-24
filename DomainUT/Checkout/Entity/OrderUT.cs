using Domain.Checkout.Entity;
using Moq;

namespace DomainUT.Checkout.Entity
{
    public class OrderUT
    {
        [Fact]
        public void Create_Order_OnSuccess()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            Guid customerId = Guid.NewGuid();

            int rewardsPoints = 100;

            ICollection<OrderItem> items = new List<OrderItem>();

            // Act
            Order order = new(id, customerId, rewardsPoints, items);

            // Assert
            Assert.True(order.Id == id);
            Assert.True(order.CustomerId == customerId);
            Assert.True(order.RewardPoints == rewardsPoints);
            Assert.True(order.Total == 0);
            Assert.True(order.Items == items);
        }

        [Fact]
        public void Create_Order_InvalidId_OnFailed()
        {
            // Arrange
            Guid id = Guid.Empty;
            Guid customerId = Guid.NewGuid();

            int rewardsPoints = 100;

            ICollection<OrderItem> items = new List<OrderItem>();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Order(id, customerId, rewardsPoints, items));
        }

        [Fact]
        public void Create_Order_InvalidCustomerId_OnFailed()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            Guid customerId = Guid.Empty;

            int rewardsPoints = 100;

            ICollection<OrderItem> items = new List<OrderItem>();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Order(id, customerId, rewardsPoints, items));
        }

        [Fact]
        public void Create_Order_InvalidRewardPoints_OnFailed()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            Guid customerId = Guid.NewGuid();

            int rewardsPoints = -100;

            ICollection<OrderItem> items = new List<OrderItem>();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Order(id, customerId, rewardsPoints, items));
        }

        [Fact]
        public void AddItem_OnSuccess()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            Guid customerId = Guid.NewGuid();

            int rewardsPoints = 100;

            Order order1 = new(id, customerId, rewardsPoints, new List<OrderItem>());
            Order order2 = new(id, customerId, rewardsPoints, new List<OrderItem>());

            // Act
            order2.AddItem(new OrderItem(Guid.NewGuid(), "item1", 1, 10, Guid.NewGuid()));

            // Assert
            Assert.True(order1.Items.Count() == 0);
            Assert.True(order2.Items.Count() == 1);
        }

        [Fact]
        public void CalculateTotal_OnSuccess()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            Guid customerId = Guid.NewGuid();

            int rewardsPoints = 100;

            ICollection<OrderItem> items = new List<OrderItem>
            {
                new OrderItem(Guid.NewGuid(), "item1", 1, 10, Guid.NewGuid()),
                new OrderItem(Guid.NewGuid(), "item2", 2, 20, Guid.NewGuid()),
            };

            // Act
            Order order = new(id, customerId, rewardsPoints, items);

            // Assert
            Assert.True(order.Total == 50);
        }
    }
}
