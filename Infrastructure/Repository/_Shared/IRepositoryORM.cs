namespace Infrastructure.Repository._Shared
{
    public interface IRepositoryORM
    {
        Task CommitAsync();

        void ClearChangeTracker();

        Task AddAsync<Model>(Model model) where Model : class;

        Task UpdateAsync<Model>(Model model) where Model : class;

        Task DeleteAsync<Model>(Model model) where Model : class;

        IQueryable<Model> Query<Model>() where Model : class;
    }
}
