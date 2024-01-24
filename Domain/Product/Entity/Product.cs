using Domain._Shared.Entity;

namespace Domain.Product.Entity
{
    public class Product : BaseEntity
    {
        public Guid Id { get; private set; }
        public float Price { get; private set; }
        public string Name { get; private set; }
        public int RewardPoints { get; private set; }

        public Product(Guid id, string name, float price, int rewardPoints = 0)
        {
            Id = id;
            Name = name;
            Price = price;
            RewardPoints = rewardPoints;

            Validate();
        }

        public override void Validate()
        {
            if (Id == Guid.Empty) throw new ArgumentException("Id is required!");
            if (string.IsNullOrEmpty(Name)) throw new ArgumentException("Name is required!");
            if (Price < 0) throw new ArgumentException("Price must be a positive number");
            if (RewardPoints < 0) throw new ArgumentException("RewardPoints must be a positive number");
        }

        public void ChangeName(string name)
        {
            Name = name;
            Validate();
        }

        public void ChangePrice(float price)
        {
            Price = price;
            Validate();
        }
        public void ChangeRewardPoints(int points)
        {
            RewardPoints = points;
            Validate();
        }
    }
}
