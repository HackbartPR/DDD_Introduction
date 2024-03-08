using Domain._Shared.Entity;

namespace Domain.Checkout.Entity
{
    public class Order : BaseEntity
    {
        public Guid Id { get; private set; }
        public float Total { get; private set; }
        public Guid CustomerId { get; private set; }
        public int RewardPoints { get; private set; }
        public ICollection<OrderItem> Items { get; private set; }

        public Order(Guid id, Guid customerId, int rewardPoints, ICollection<OrderItem> items)
        {
            Id = id;
            Items = items;
            Total = CalculateTotal();
            CustomerId = customerId;
            RewardPoints = rewardPoints;

            Validate();
        }

        public override void Validate()
        {
            if (Id == Guid.Empty) throw new ArgumentException("Id is required!");
            if (CustomerId == Guid.Empty) throw new ArgumentException("CustomerId is required!");
            if (RewardPoints < 0) throw new ArgumentException("RewardPoints must be a positive number");
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
            CalculateTotal();
        }

        private float CalculateTotal()
        {
            return Items.Any() ? Items.Aggregate(0f, (result, item) => result + item.Total) : 0;
        }
    }
}
