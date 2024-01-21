namespace DomainUT.Product.Entity
{
    public class ProductUT
    {
        [Fact]
        public void Create_Product_OnSuccess()
        {
            // Arrange
            int price = 100;
            int rewardPoints = 0;
            string name = "Teste";
            Guid id = Guid.NewGuid();

            // Act
            Domain.Product.Entity.Product product = new(id, name, price);

            // Assert
            Assert.True(product.Id == id);
            Assert.True(product.Name == name);
            Assert.True(product.Price == price);
            Assert.True(product.RewardPoints == rewardPoints);
        }

        [Fact]
        public void Create_Product_InvalidId_OnFailed()
        {
            // Arrange
            int price = 100;
            int rewardPoints = 0;
            string name = "Teste";
            Guid id = Guid.Empty;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Domain.Product.Entity.Product(id, name, price, rewardPoints));
        }

        [Fact]
        public void Create_Product_InvalidName_OnFailed()
        {
            // Arrange
            int price = 100;
            int rewardPoints = 0;
            string name = string.Empty;
            Guid id = Guid.NewGuid();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Domain.Product.Entity.Product(id, name, price, rewardPoints));
        }

        [Fact]
        public void Create_Product_InvalidPrice_OnFailed()
        {
            // Arrange
            int price = -100;
            int rewardPoints = 0;
            string name = "Teste";
            Guid id = Guid.NewGuid();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Domain.Product.Entity.Product(id, name, price, rewardPoints));
        }

        [Fact]
        public void Create_Product_InvalidRewardPoints_OnFailed()
        {
            // Arrange
            int price = 100;
            int rewardPoints = -10;
            string name = "Teste";
            Guid id = Guid.NewGuid();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Domain.Product.Entity.Product(id, name, price, rewardPoints));
        }

        [Fact]
        public void ChangeName_OnSuccess()
        {
            // Arrange
            int price = 100;
            Guid id = Guid.NewGuid();

            string name = "Teste";
            string newName = "Teste";

            Domain.Product.Entity.Product product = new(id, name, price);

            // Act
            product.ChangeName(newName);

            // Assert
            Assert.True(product.Name == newName);
        }

        [Fact]
        public void ChangeName_OnFailed()
        {
            // Arrange
            int price = 100;
            Guid id = Guid.NewGuid();

            string name = "Teste";
            string newName = string.Empty;

            Domain.Product.Entity.Product product = new(id, name, price);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => product.ChangeName(newName));
        }

        [Fact]
        public void ChangePrice_OnSuccess()
        {
            // Arrange
            string name = "Teste";
            Guid id = Guid.NewGuid();

            int price = 100;
            int newPrice = 200;

            Domain.Product.Entity.Product product = new(id, name, price);

            // Act
            product.ChangePrice(newPrice);

            // Assert
            Assert.True(product.Price == newPrice);
        }

        [Fact]
        public void ChangePrice_OnFailed()
        {
            // Arrange
            string name = "Teste";
            Guid id = Guid.NewGuid();

            int price = 100;
            int newPrice = -200;

            Domain.Product.Entity.Product product = new(id, name, price);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => product.ChangePrice(newPrice));
        }

        [Fact]
        public void ChangeRewardPoints_OnSuccess()
        {
            // Arrange
            int price = 100;
            string name = "Teste";
            Guid id = Guid.NewGuid();

            int rewardPoints = 200;
            int newRewardPoints = 200;

            Domain.Product.Entity.Product product = new(id, name, price, rewardPoints);

            // Act
            product.ChangeRewardPoints(newRewardPoints);

            // Assert
            Assert.True(product.RewardPoints == newRewardPoints);
        }

        [Fact]
        public void ChangeRewardPoints_OnFailed()
        {
            // Arrange
            int price = 100;
            string name = "Teste";
            Guid id = Guid.NewGuid();

            int rewardPoints = 200;
            int newRewardPoints = -200;

            Domain.Product.Entity.Product product = new(id, name, price, rewardPoints);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => product.ChangeRewardPoints(newRewardPoints));
        }

    }
}
