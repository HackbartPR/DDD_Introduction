using Domain.Customer.ValueObject;

namespace DomainUT.Customer.Entity
{
    public class CustomerUT
    {
        [Fact]
        public void Create_Customer_OnSuccess()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            string name = "Teste";

            // Act
            Domain.Customer.Entity.Customer customer = new(id, name);

            // Assert
            Assert.True(customer.Id == id);
            Assert.True(customer.Name == name);
        }

        [Fact]
        public void Create_Customer_InvalidName_OnFailed()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            string name = string.Empty;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Domain.Customer.Entity.Customer(id, name));
        }

        [Fact]
        public void Create_Customer_InvalidId_OnFailed()
        {
            // Arrange
            Guid emptyGuid = Guid.Empty;
            string name = "Teste";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Domain.Customer.Entity.Customer(emptyGuid, name));
        }

        [Fact]
        public void ChangeName_OnSuccess()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            string name = "Teste";
            string newName = "Teste Changed";
            
            Domain.Customer.Entity.Customer customer = new(id, name);

            // Act
            customer.ChangeName(newName);

            // Assert
            Assert.True(customer.Name == newName);
        }

        [Fact]
        public void ChangeName_OnFailed()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            string name = "Teste";
            string newName = string.Empty;

            Domain.Customer.Entity.Customer customer = new(id, name);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => customer.ChangeName(newName));
        }

        [Fact]
        public void ChangeAddres_OnSuccess()
        {
            // Arrange
            string name = "Teste";
            Guid id = Guid.NewGuid();
            Address address = new("street", "city", "123");

            Domain.Customer.Entity.Customer customer = new(id, name);

            // Act
            customer.ChangeAddress(address);

            // Assert
            Assert.True(customer.Address == address);
        }

        [Fact]
        public void Activation_OnSuccess()
        {
            // Arrange
            string name = "Teste";
            Guid id = Guid.NewGuid();
            Address address = new("street", "city", "123");

            Domain.Customer.Entity.Customer customer = new(id, name);
            customer.ChangeAddress(address);

            // Act
            customer.Activation();

            // Assert
            Assert.True(customer.Active);
        }

        [Fact]
        public void Activation_OnFailed()
        {
            // Arrange
            string name = "Teste";
            Guid id = Guid.NewGuid();
            Address address = new("street", "city", "123");

            Domain.Customer.Entity.Customer customer = new(id, name);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => customer.Activation());
        }

        [Fact]
        public void Deactivation_OnSuccess()
        {
            // Arrange
            string name = "Teste";
            Guid id = Guid.NewGuid();

            Domain.Customer.Entity.Customer customer = new(id, name);

            // Act
            customer.Deactivation();

            // Assert
            Assert.False(customer.Active);
        }

        [Fact]
        public void AddRewardPoints_OnSuccess()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            string name = "Teste";

            Domain.Customer.Entity.Customer customer = new(id, name);

            // Act
            customer.AddRewardPoints(10);
            customer.AddRewardPoints(20);

            // Assert
            Assert.True(customer.RewardPoints == 30);
        }

        [Fact]
        public void AddRewardPoints_OnFailed()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            string name = "Teste";

            Domain.Customer.Entity.Customer customer = new(id, name);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => customer.AddRewardPoints(-10));
        }
    }
}
