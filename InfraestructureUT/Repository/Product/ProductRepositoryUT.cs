using Domain._Shared.Repository;
using InfraestructureUT.Database.EntityFramework.Settings;
using Infrastructure.Database.EntityFramework.Repository;
using Infrastructure.Repository;
using Infrastructure.Repository._Shared;

namespace InfraestructureUT.Repository.Product
{
    public class ProductRepositoryUT
    {
        private readonly IRepositoryORM repositoryORM;
        private readonly IBaseRepository<Domain.Product.Entity.Product> productRepository;

        public ProductRepositoryUT() 
        {
            repositoryORM = new EntityFrameworkRepository(EFContextUT.GetContext());
            productRepository = new ProductRepository(repositoryORM);
        }

        [Fact]
        public async Task Create_Successfuly()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            Domain.Product.Entity.Product product = new(id, "Produto 1", 100);

            // Act
            await productRepository.CreateAsync(product);
            Domain.Product.Entity.Product? result = await productRepository.FindAsync(id);

            // Assert
            Assert.Equivalent(product, result);
        }
    }
}
