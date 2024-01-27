using Domain._Shared.Repository;
using InfraestructureUT.Database.EntityFramework.Settings;
using Infrastructure.Database.EntityFramework.Repository;
using Infrastructure.Repository._Shared;
using Infrastructure.Repository.Product;

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

        [Fact]
        public async Task Update_Successfuly()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            Domain.Product.Entity.Product product = new(id, "Produto 1", 100);

            // Act & Assert
            await productRepository.CreateAsync(product);
            Domain.Product.Entity.Product? resultFromCreate = await productRepository.FindAsync(id);
            
            Assert.Equivalent(product, resultFromCreate);

            resultFromCreate!.ChangeName("Produto 1 Alterado");
            resultFromCreate.ChangePrice(200);
            resultFromCreate.ChangeRewardPoints(10);
            await productRepository.UpdateAsync(resultFromCreate);
            Domain.Product.Entity.Product? resultFromUpdate = await productRepository.FindAsync(id);

            Assert.Equivalent(resultFromCreate, resultFromUpdate);
        }

        [Fact]
        public async Task FindAll_Successfuly()
        {
            // Arrange
            Domain.Product.Entity.Product product1 = new(Guid.NewGuid(), "Produto 1", 100);
            Domain.Product.Entity.Product product2 = new(Guid.NewGuid(), "Produto 2", 200);

            ICollection<Domain.Product.Entity.Product> expected = new List<Domain.Product.Entity.Product> { product1, product2 };

            await productRepository.CreateAsync(product1);
            await productRepository.CreateAsync(product2);

            // Act
            var result = await productRepository.FindAllAsync();

            // Assert
            Assert.Equivalent(result, expected);
        }
    }
}
