namespace Domain._Shared.Repository
{
    public interface IBaseRepository<T>
    {
        Task CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task<T?> FindAsync(Guid Id);

        Task<ICollection<T>> FindAllAsync();
    }
}
