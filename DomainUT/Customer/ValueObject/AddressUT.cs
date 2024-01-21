using Domain.Customer.ValueObject;
using System.IO;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace DomainUT.Customer.ValueObject
{
    public class AddressUT
    {
        [Fact]
        public void Create_Address_OnSuccess()
        {
            // Arrange
            string street = "Street";
            string city = "City";
            string zipCode = "ZipCode";

            // Act
            Address address = new(street, city, zipCode);

            // Assert
            Assert.True(address.Street == street);
            Assert.True(address.City == city);
            Assert.True(address.ZipCode == zipCode);
        }

        [Fact]
        public void Create_Address_InvalidStreet_OnFailed()
        {
            // Arrange
            string street = string.Empty;
            string city = "City";
            string zipCode = "ZipCode";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Address(street, city, zipCode));
        }

        [Fact]
        public void Create_Address_InvalidCity_OnFailed()
        {
            // Arrange
            string street = "Street";
            string city = string.Empty;
            string zipCode = "ZipCode";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Address(street, city, zipCode));
        }

        [Fact]
        public void Create_Address_InvalidZipCode_OnFailed()
        {
            // Arrange
            string street = "Street";
            string city = "City";
            string zipCode = string.Empty;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Address(street, city, zipCode));
        }

        [Fact]
        public void ToString_OnSuccess()
        {
            // Arrange
            string street = "Street";
            string city = "City";
            string zipCode = "ZipCode";

            string expected = $"{street}, {zipCode} - {city}";

            // Act
            Address address = new(street, city, zipCode);

            // Assert
            Assert.True(address.ToString() == expected);
        }
    }
}
