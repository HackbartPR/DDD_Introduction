using InfraestructureUT.Database.EntityFramework.Settings;
using Infrastructure.Database.EntityFramework.Settings;
using Microsoft.EntityFrameworkCore;

namespace InfraestructureUT.Repository.Product
{
    public class ProductRepositoryUT
    {
        // Teste para verificar o funcionamento do DbContext
        [Fact]
        public async Task Testando()
        {
            var context = EFContextUT.GetContext();

            await context.Products.AddAsync(new Infrastructure.Database.EntityFramework.Model.Product() { Id = Guid.NewGuid(), Name = "Teste", Price = 10, RewardsPoints = 100 });
            await context.SaveChangesAsync();

            ICollection<Infrastructure.Database.EntityFramework.Model.Product> result =await context.Products.ToListAsync();

            Assert.Single(result);
            Assert.Contains(result, p => p.Name == "Teste");

        }
    }
}
