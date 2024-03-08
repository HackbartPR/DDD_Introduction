using Infrastructure.Database.EntityFramework.Settings;
using Infrastructure.Repository._Shared;

namespace Infrastructure.Database.EntityFramework.Repository
{
    public class EntityFrameworkRepository : IRepositoryORM
    {
        private readonly EFContext _context;

        public EntityFrameworkRepository(EFContext context)
            => _context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task AddAsync<Model>(Model model) where Model : class
        {
            if (model == null) throw new ArgumentNullException("Model can not be null");

            await _context.Set<Model>().AddAsync(model);
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void ClearChangeTracker()
        {
            _context.ChangeTracker.Clear();
        }

        public async Task DeleteAsync<Model>(Model model) where Model : class
        {
            if (model == null) throw new ArgumentNullException("Model can not be null");

            await Task.CompletedTask;
            _context.Set<Model>().Remove(model);
        }

        public async Task UpdateAsync<Model>(Model model) where Model : class
        {
            if (model == null) throw new ArgumentNullException("Model can not be null");

            await Task.CompletedTask;
            _context.Set<Model>().Update(model);
        }

        public IQueryable<Model> Query<Model>() where Model : class
        {
            return _context.Set<Model>().AsQueryable();
        }
    }
}
