using Domain._Shared.Repository;
using Domain.Customer.ValueObject;
using Infrastructure.Database.EntityFramework.Model;
using Infrastructure.Repository._Shared;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Customer
{
    public class CustomerRepository : IBaseRepository<Domain.Customer.Entity.Customer>
    {
        private readonly IRepositoryORM _repository;

        public CustomerRepository(IRepositoryORM repository)
            => _repository = repository ?? throw new ArgumentNullException(nameof(repository));

        public async Task CreateAsync(Domain.Customer.Entity.Customer entity)
        {
            CustomerModel model = new() 
            {
                Id = entity.Id,
                Name = entity.Name,
                Active = entity.Active,
                RewardsPoints = entity.RewardPoints,
                City = entity.Address?.City,
                Street = entity.Address?.Street,
                ZipCode = entity.Address?.ZipCode
            };

            await _repository.AddAsync(model);
            await _repository.CommitAsync();
        }
        public async Task UpdateAsync(Domain.Customer.Entity.Customer entity)
        {
            IQueryable<CustomerModel> query = _repository.Query<CustomerModel>();
            CustomerModel? model = await query.FirstOrDefaultAsync(m => m.Id.Equals(entity.Id))
                ?? throw new InvalidOperationException("Customer not found");

            model.Name = entity.Name;
            model.Active = entity.Active;   
            model.RewardsPoints = entity.RewardPoints;
            model.Street = entity.Address?.Street;
            model.City = entity.Address?.City;
            model.ZipCode = entity.Address?.ZipCode;

            await _repository.UpdateAsync(model);
            await _repository.CommitAsync();
        }
        public async Task<Domain.Customer.Entity.Customer?> FindAsync(Guid Id)
        {
            IQueryable<CustomerModel> query = _repository.Query<CustomerModel>();
            CustomerModel? model = await query.FirstOrDefaultAsync(m => m.Id.Equals(Id));

            if (model == null) return null;

            Domain.Customer.Entity.Customer entity = new (model.Id, model.Name);
            entity.AddRewardPoints(model.RewardsPoints);

            if (model.Street != null && model.City != null && model.ZipCode != null)
                entity.ChangeAddress(new(model.Street, model.City, model.ZipCode));
            
            if (model.Active) entity.Activation();

            return entity;
        }

        public async Task<ICollection<Domain.Customer.Entity.Customer>> FindAllAsync()
        {
            IQueryable<CustomerModel> query = _repository.Query<CustomerModel>();
            ICollection<CustomerModel> collection = await query.ToListAsync();

            ICollection<Domain.Customer.Entity.Customer> customers = new List<Domain.Customer.Entity.Customer>();
            foreach (CustomerModel model in collection)
            {
                Domain.Customer.Entity.Customer entity = new(model.Id, model.Name);
                entity.AddRewardPoints(model.RewardsPoints);

                if (model.Street != null && model.City != null && model.ZipCode != null)
                    entity.ChangeAddress(new(model.Street, model.City, model.ZipCode));

                if (model.Active) entity.Activation();

                customers.Add(entity);
            }

            return customers;
        }
    }
}
