using Domain._Shared.Repository;
using InfraestructureUT.Database.EntityFramework.Settings;
using Infrastructure.Database.EntityFramework.Repository;
using Infrastructure.Repository._Shared;
using Infrastructure.Repository.Customer;

namespace InfraestructureUT.Repository.Customer
{
    public class CustomerRepositoryUT
    {
        private readonly IRepositoryORM repositoryORM;
        private readonly IBaseRepository<Domain.Customer.Entity.Customer> customerRepository;

        public CustomerRepositoryUT() 
        {
            repositoryORM = new EntityFrameworkRepository(EFContextUT.GetContext());
            customerRepository = new CustomerRepository(repositoryORM);
        }

        [Fact]
        public async Task Create_Successfuly()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            Domain.Customer.Entity.Customer customer = new(id, "Customer 1");
            customer.ChangeAddress(new Domain.Customer.ValueObject.Address("Street 1", "City 1", "12345"));

            // Act
            await customerRepository.CreateAsync(customer);
            Domain.Customer.Entity.Customer? result = await customerRepository.FindAsync(id);

            // Assert
            Assert.Equivalent(customer, result);
        }

        [Fact]
        public async Task Create_Without_Address_Successfuly()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            Domain.Customer.Entity.Customer customer = new(id, "Customer 1");

            // Act
            await customerRepository.CreateAsync(customer);
            Domain.Customer.Entity.Customer? result = await customerRepository.FindAsync(id);

            // Assert
            Assert.Equivalent(customer, result);
        }

        [Fact]
        public async Task Update_Successfuly()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            Domain.Customer.Entity.Customer customer = new(id, "Customer 1");
            customer.ChangeAddress(new Domain.Customer.ValueObject.Address("Street 1", "City 1", "12345"));

            // Act & Assert
            await customerRepository.CreateAsync(customer);
            Domain.Customer.Entity.Customer? resultFromCreate = await customerRepository.FindAsync(id);

            Assert.Equivalent(customer, resultFromCreate);

            resultFromCreate!.ChangeName("Produto 1 Alterado");
            resultFromCreate.Activation();
            resultFromCreate.ChangeAddress(new Domain.Customer.ValueObject.Address("Street 2", "City 2", "54321"));

            await customerRepository.UpdateAsync(resultFromCreate);
            Domain.Customer.Entity.Customer? resultFromUpdate = await customerRepository.FindAsync(id);

            Assert.Equivalent(resultFromCreate, resultFromUpdate);
        }

        [Fact]
        public async Task FindAll_Successfuly()
        {
            // Arrange
            Domain.Customer.Entity.Customer customer1 = new(Guid.NewGuid(), "Customer 1");
            customer1.ChangeAddress(new Domain.Customer.ValueObject.Address("Street 1", "City 1", "12345"));

            Domain.Customer.Entity.Customer customer2 = new(Guid.NewGuid(), "Customer 2");
            customer2.ChangeAddress(new Domain.Customer.ValueObject.Address("Street 2", "City 2", "54321"));

            ICollection<Domain.Customer.Entity.Customer> expected = new List<Domain.Customer.Entity.Customer> { customer1, customer2 };

            await customerRepository.CreateAsync(customer1);
            await customerRepository.CreateAsync(customer2);

            // Act
            var result = await customerRepository.FindAllAsync();

            // Assert
            Assert.Equivalent(result, expected);
        }
    }
}
