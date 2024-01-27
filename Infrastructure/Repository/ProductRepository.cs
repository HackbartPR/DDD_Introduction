using Domain._Shared.Repository;
using Domain.Product.Entity;
using Infrastructure.Database.EntityFramework.Model;
using Infrastructure.Repository._Shared;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ProductRepository : IBaseRepository<Product>
    {
        private readonly IRepositoryORM _repository;

        public ProductRepository(IRepositoryORM repository)
            => _repository = repository ?? throw new ArgumentNullException(nameof(repository));

        public async Task CreateAsync(Product entity)
        {
            ProductModel product = new()
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price,
                RewardsPoints = entity.RewardPoints,
            };

            await _repository.AddAsync<ProductModel>(product);
            await _repository.CommitAsync();
        }

        public Task<ICollection<Product>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Product?> FindAsync(Guid Id)
        {
            IQueryable<ProductModel> query = _repository.Query<ProductModel>();
            ProductModel? model = await query.FirstOrDefaultAsync(p => p.Id.Equals(Id));

            if (model == null) return null;
            return new Product(Id, model.Name, model.Price, model.RewardsPoints);
        }

        public Task UpdateAsync(Product entity)
        {

            throw new NotImplementedException();
        }
    }
}
