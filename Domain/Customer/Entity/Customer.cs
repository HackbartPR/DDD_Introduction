using Domain._Shared.Entity;
using Domain.Customer.ValueObject;

namespace Domain.Customer.Entity
{
    public class Customer : BaseEntity
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public bool Active { get; private set; }
        public Address? Address { get; private set; }
        public int RewardPoints { get; private set; }

        public Customer(Guid id, string name)
        {
            Id = id;
            Name = name;
            Active = false;
            RewardPoints = 0;

            Validate();
        }

        public override void Validate()
        {
            if (Id == Guid.Empty) throw new ArgumentException("Id is required!");
            if (string.IsNullOrEmpty(Name)) throw new ArgumentException("Name is required!");
            if (RewardPoints < 0) throw new ArgumentException("RewardPoints must be a positive number");
        }

        public void ChangeName(string name)
        {
            Name = name;
            Validate();
        }

        public void ChangeAddress(Address address)
        {
            Address = address;
        }

        public void Activation()
        {
            if (Address == null) throw new ArgumentNullException("Addres is requires to active a customer");

            Active = true;
        }

        public void Deactivation()
        {
            Active = false;
        }

        public void AddRewardPoints(int rewardPoints)
        {
            RewardPoints += rewardPoints;
            Validate();
        }
    }
}
