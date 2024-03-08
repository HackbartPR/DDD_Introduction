using Domain.Checkout.Entity;

namespace DomainUT.Checkout.Entity
{
    public class OrderItemUT
    {
        [Fact]
        public void Create_OrderItem_OnSuccess()
        {
            // Arrange
            long price = 10;
            int quantity = 2;
            string name = "Teste";
            Guid id = Guid.NewGuid();
            long total = quantity * price;

            // Act
            OrderItem product = new(id, name, quantity, price, Guid.NewGuid());

            // Assert
            Assert.True(product.Id == id);
            Assert.True(product.Name == name);
            Assert.True(product.Price == price);
            Assert.True(product.Total == total);
            Assert.True(product.Quantity == quantity);
        }

        [Fact]
        public void Create_OrderItem_InvalidId_OnFailed()
        {
            // Arrange
            long price = 10;
            int quantity = 2;
            Guid id = Guid.Empty;
            string name = "Teste";
            long total = quantity * price;
            Guid productId = Guid.NewGuid();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new OrderItem(id, name, quantity, price, productId));
        }

        [Fact]
        public void Create_OrderItem_InvalidName_OnFailed()
        {
            // Arrange
            long price = 10;
            int quantity = 2;
            Guid id = Guid.NewGuid();
            string name = string.Empty;
            long total = quantity * price;
            Guid productId = Guid.NewGuid();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new OrderItem(id, name, quantity, price, productId));
        }

        [Fact]
        public void Create_OrderItem_Price_OnFailed()
        {
            // Arrange
            long price = -10;
            int quantity = 2;
            Guid id = Guid.NewGuid();
            string name = "Teste";
            long total = quantity * price;
            Guid productId = Guid.NewGuid();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new OrderItem(id, name, quantity, price, productId));
        }

        [Fact]
        public void Create_OrderItem_Quantity_OnFailed()
        {
            // Arrange
            long price = 10;
            int quantity = -2;
            Guid id = Guid.NewGuid();
            string name = "Teste";
            long total = quantity * price;
            Guid productId = Guid.NewGuid();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new OrderItem(id, name, quantity, price, productId));
        }

        [Fact]
        public void Create_OrderItem_ProductId_OnFailed()
        {
            // Arrange
            long price = 10;
            int quantity = 2;
            Guid id = Guid.NewGuid();
            string name = "Teste";
            long total = quantity * price;
            Guid productId = Guid.Empty;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new OrderItem(id, name, quantity, price, productId));
        }

        [Fact]
        public void ChangePrice_OnSuccess()
        {
            // Arrange
            string name = "Teste";
            Guid id = Guid.NewGuid();

            int price = 100;
            int newPrice = 200;

            OrderItem item = new(id, name, 2, price, Guid.NewGuid());

            // Act
            item.ChangePrice(newPrice);

            // Assert
            Assert.True(item.Price == newPrice);
        }

        [Fact]
        public void ChangePrice_OnFailed()
        {
            // Arrange
            string name = "Teste";
            Guid id = Guid.NewGuid();

            int price = 100;
            int newPrice = -200;

            OrderItem item = new(id, name, 2, price, Guid.NewGuid());

            // Act & Assert
            Assert.Throws<ArgumentException>(() => item.ChangePrice(newPrice));
        }

        [Fact]
        public void ChangeQuantity_OnSuccess()
        {
            // Arrange
            string name = "Teste";
            Guid id = Guid.NewGuid();

            int quantity = 2;
            int newQuant = 3;

            OrderItem item = new(id, name, quantity, 10, Guid.NewGuid());

            // Act
            item.ChangeQuantity(newQuant);

            // Assert
            Assert.True(item.Quantity == newQuant);
        }

        [Fact]
        public void ChangeQuantity_OnFailed()
        {
            // Arrange
            string name = "Teste";
            Guid id = Guid.NewGuid();

            int quantity = 2;
            int newQuant = -3;

            OrderItem item = new(id, name, quantity, 10, Guid.NewGuid());

            // Act & Assert
            Assert.Throws<ArgumentException>(() => item.ChangeQuantity(newQuant));
        }

        [Fact]
        public void CalculateTotal_ChangingQuantity_OnSuccess()
        {
            // Arrange
            float price = 10;
            int newQuant = 2;
            int currQuant = 1;

            float expecNewTotal = 20;
            float expecCurrTotal = 10;

            // Act
            OrderItem item = new(Guid.NewGuid(), "Item 1", currQuant, price, Guid.NewGuid());
            float currTotal = item.Total;

            item.ChangeQuantity(newQuant);
            float newTotal = item.Total;

            // Assert
            Assert.True(currTotal == expecCurrTotal);
            Assert.True(newTotal == expecNewTotal);
        }

        [Fact]
        public void CalculateTotal_ChangingPrice_OnSuccess()
        {
            // Arrange
            int quantity = 2;
            float newPrice = 20;
            float currPrice = 10;

            float expecNewTotal = 40;
            float expecCurrTotal = 20;

            // Act
            OrderItem item = new(Guid.NewGuid(), "Item 1", quantity, currPrice, Guid.NewGuid());
            float currTotal = item.Total;

            item.ChangePrice(newPrice);
            float newTotal = item.Total;

            // Assert
            Assert.True(currTotal == expecCurrTotal);
            Assert.True(newTotal == expecNewTotal);
        }
    }
}
