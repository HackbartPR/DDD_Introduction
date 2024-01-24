using Domain.Product.Services;

namespace DomainUT.Product.Services
{
    public class ProductServiceUT
    {
        [Fact]
        public void IncreasePrice_Successfuly()
        {
            // Arrange
            var product1 = new Domain.Product.Entity.Product(Guid.NewGuid(), "First", 10);
            var product2 = new Domain.Product.Entity.Product(Guid.NewGuid(), "Second", 20);

            var expected1 = 11;
            var expected2 = 22;

            ICollection<Domain.Product.Entity.Product> products = new List<Domain.Product.Entity.Product>{product1, product2};

            // Act
            ProductService.IncreasePrice(products, 10);

            // Assert
            Assert.True(product1.Price == expected1);
            Assert.True(product2.Price == expected2);
        }
    }
}
