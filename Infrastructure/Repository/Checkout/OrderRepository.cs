using Domain._Shared.Repository;
using Domain.Checkout.Entity;
using Infrastructure.Database.EntityFramework.Model;
using Infrastructure.Repository._Shared;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Checkout
{
    public class OrderRepository : IBaseRepository<Domain.Checkout.Entity.Order>
    {
        private readonly IRepositoryORM _repository;

        public OrderRepository(IRepositoryORM repository)
            => _repository = repository ?? throw new ArgumentNullException(nameof(repository));

        public async Task CreateAsync(Order entity)
        {
            OrderModel model = new() 
            {
                Id = entity.Id,
                CustomerId = entity.CustomerId,
                RewardPoints = entity.RewardPoints,
                Total = entity.Total,
                Items = entity.Items.Select(i => new OrderItemModel
                {
                    Id = i.Id,
                    Name = i.Name,
                    Price = i.Price,
                    Total = i.Total,
                    Quantity = i.Quantity,
                    ProductId = i.ProductId,
                }).ToList(),
            };

            await _repository.AddAsync(model);
            await _repository.CommitAsync();
        }

        public Task<ICollection<Order>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Order?> FindAsync(Guid Id)
        {
            IQueryable<OrderModel> query = _repository.Query<OrderModel>().AsNoTracking();
            OrderModel? model = await query.Include(o => o.Items).FirstOrDefaultAsync(o => o.Id.Equals(Id));

            if (model == null) return null;

            ICollection<OrderItem> items = model.Items.Select(i => new OrderItem(i.Id, i.Name, i.Quantity, i.Price, i.ProductId)).ToList();
            Order order = new(model.Id, model.CustomerId, model.RewardPoints, items);

            return order;
        }

        public async Task UpdateAsync(Order entity)
        {
            IQueryable<OrderModel> query = _repository.Query<OrderModel>();
            OrderModel? model = await query.FirstOrDefaultAsync(o => o.Id.Equals(entity.Id))
                ?? throw new InvalidOperationException("Order not found");

            ICollection<OrderItemModel> items = entity.Items.Select(i => new OrderItemModel
            {
                Id = i.Id,
                Name = i.Name,
                Price = i.Price,
                Total = i.Total,
                Quantity = i.Quantity,
                ProductId = i.ProductId
            }).ToList();

            model.Id = entity.Id;
            model.Items = items;
            model.CustomerId = entity.CustomerId;
            model.RewardPoints = entity.RewardPoints;
            model.Total = entity.Total;

            await _repository.UpdateAsync(model);
            await _repository.CommitAsync();
        }
    }
}
