using Domain._Shared.Repository;
using Infrastructure.Database.EntityFramework.Model;
using Infrastructure.Repository._Shared;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Product
{
    public class ProductRepository : IBaseRepository<Domain.Product.Entity.Product>
    {
        private readonly IRepositoryORM _repository;

        public ProductRepository(IRepositoryORM repository)
            => _repository = repository ?? throw new ArgumentNullException(nameof(repository));

        public async Task CreateAsync(Domain.Product.Entity.Product entity)
        {
            ProductModel product = new()
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price,
                RewardsPoints = entity.RewardPoints,
            };

            await _repository.AddAsync(product);
            await _repository.CommitAsync();
        }

        public Task<ICollection<Domain.Product.Entity.Product>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Domain.Product.Entity.Product?> FindAsync(Guid Id)
        {
            IQueryable<ProductModel> query = _repository.Query<ProductModel>();
            ProductModel? model = await query.FirstOrDefaultAsync(p => p.Id.Equals(Id));

            if (model == null) return null;
            return new Domain.Product.Entity.Product(Id, model.Name, model.Price, model.RewardsPoints);
        }

        public Task UpdateAsync(Domain.Product.Entity.Product entity)
        {

            throw new NotImplementedException();
        }
    }
}
