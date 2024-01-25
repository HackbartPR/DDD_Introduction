using Infrastructure.Database.EntityFramework.Settings;
using Microsoft.EntityFrameworkCore;

namespace InfraestructureUT.Database.EntityFramework.Settings
{
    public abstract class EFContextUT
    {
        public static EFContext GetContext()
        {
            DbContextOptionsBuilder<EFContext> builder = new();
            builder.UseSqlite("DataSource=:memory:");

            EFContext context = new(builder.Options);
            context.Database.OpenConnection();

            context.Database.EnsureCreated();
            return context;
        }
    }
}
