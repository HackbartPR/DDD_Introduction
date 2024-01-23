using Domain._Shared.Entity;

namespace Domain.Checkout.Entity
{
    public class OrderItem : BaseEntity
    {
        public Guid Id { get; private set; }
        public long Price { get; private set; }
        public long Total { get; private set; }
        public string Name { get; private set; }
        public int Quantity { get; private set; }
        public Guid ProductId { get; private set; }

        public OrderItem(Guid id, string name, int quantity, long price, Guid productId)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = quantity;
            ProductId = productId;
            Total = CalculateTotal();

            Validate();
        }

        public override void Validate()
        {
            if (Id == Guid.Empty) throw new ArgumentException("Id is required!");
            if (string.IsNullOrEmpty(Name)) throw new ArgumentException("Name is required!");
            if (Quantity <= 0) throw new ArgumentException("Quantity shoud be a positive number");
            if (Price < 0) throw new ArgumentException("Quantity shoud be a positive number");
            if (ProductId == Guid.Empty) throw new ArgumentException("ProductId is required!");
        }

        public void ChangePrice(long price) 
        { 
            Price = price;
            Total = CalculateTotal();

            Validate();
        }

        public void ChangeQuantity(int  quantity)
        {
            Quantity = quantity;
            Total = CalculateTotal();

            Validate();
        }

        private long CalculateTotal()
        {
            return Quantity * Price;
        }
    }
}
