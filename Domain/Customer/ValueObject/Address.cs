using Domain._Shared.Entity;

namespace Domain.Customer.ValueObject
{
    public class Address : BaseEntity
    {
        public string Street {get; private set;}
        public string City { get; private set; }
        public string ZipCode { get; private set; }

        public Address(string street, string city, string zipCode)
        {
            Street = street;
            City = city;
            ZipCode = zipCode;

            Validate();
        }

        public override void Validate()
        {
            if (string.IsNullOrEmpty(Street)) throw new ArgumentException("Street is required!");
            if (string.IsNullOrEmpty(City)) throw new ArgumentException("City is required!");
            if (string.IsNullOrEmpty(ZipCode)) throw new ArgumentException("ZipCode is required!");
        }

        public override string ToString()
        {
            return $"{Street}, {ZipCode} - {City}";
        }
    }
}
