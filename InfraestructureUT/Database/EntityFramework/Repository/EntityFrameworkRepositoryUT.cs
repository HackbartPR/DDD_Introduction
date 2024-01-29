using InfraestructureUT.Database.EntityFramework.Settings;
using Infrastructure.Database.EntityFramework.Model;
using Infrastructure.Database.EntityFramework.Repository;
using Infrastructure.Repository._Shared;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Xml.Linq;

namespace InfraestructureUT.Database.EntityFramework.Repository
{
    public class EntityFrameworkRepositoryUT
    {
        private readonly IRepositoryORM _repository;
        public EntityFrameworkRepositoryUT() 
        {
            _repository = new EntityFrameworkRepository(EFContextUT.GetContext());
        }

        [Fact]
        public async Task AddAsync_And_Query_Successfuly()
        {
            // Arrange
            ProductModel model = new() 
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                Price = 10.5f,
                RewardPoints = 10
            };

            var query = _repository.Query<ProductModel>();

            // Act
            await _repository.AddAsync(model);
            await _repository.CommitAsync();

            ProductModel? result = await query.FirstOrDefaultAsync(m => m.Id.Equals(model.Id));

            // Assert
            Assert.Equivalent(result, model);
        }

        [Fact]
        public async Task AddAsync_NullModel_OnFailed()
        {
            // Arrange
            ProductModel? product = null;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await _repository.AddAsync(product));
        }

        [Fact]
        public async Task DeleteAsync_Successfuly()
        {
            // Arrange
            ProductModel model = new()
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                Price = 10.5f,
                RewardPoints = 10
            };

            var query = _repository.Query<ProductModel>();

            // Act & Assert
            await _repository.AddAsync(model);
            await _repository.CommitAsync();

            ProductModel? result = await query.FirstOrDefaultAsync(m => m.Id.Equals(model.Id));
            Assert.Equivalent(result, model);

            await _repository.DeleteAsync(model);
            await _repository.CommitAsync();

            result = await query.FirstOrDefaultAsync(m => m.Id.Equals(model.Id));
            Assert.Null(result);
        }

        [Fact]
        public async Task DeleteAsync_NullModel_OnFailed()
        {
            // Arrange
            ProductModel? product = null;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await _repository.DeleteAsync(product));
        }

        [Fact]
        public async Task UpdateAsync_Successfuly()
        {
            // Arrange
            ProductModel model = new()
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                Price = 10.5f,
                RewardPoints = 10
            };

            ProductModel modelUpdated = model;
            model.Name = "Test Updated";

            var query = _repository.Query<ProductModel>();

            // Act & Assert
            await _repository.AddAsync(model);
            await _repository.CommitAsync();

            ProductModel? result = await query.FirstOrDefaultAsync(m => m.Id.Equals(model.Id));
            Assert.Equivalent(result, model);
            
            result!.Name = "Test Updated";
            result!.Price = 10;
            result!.RewardPoints = 20;

            await _repository.UpdateAsync(modelUpdated);
            await _repository.CommitAsync();

            result = await query.FirstOrDefaultAsync(m => m.Id.Equals(model.Id));
            
            Assert.True(result!.Name.Equals("Test Updated"));
            Assert.True(result!.Price == 10);
            Assert.True(result!.RewardPoints == 20);
        }

        [Fact]
        public async Task UpdateAsync_NullModel_OnFailed()
        {
            // Arrange
            ProductModel? product = null;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await _repository.UpdateAsync(product));
        }
    }
}
