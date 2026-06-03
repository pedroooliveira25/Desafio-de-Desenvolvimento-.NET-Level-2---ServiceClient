public interface ICrudRepository<T>
{
    Task AddAsync(T entity);
    Task<T> GetByIdAsync(Guid id);
    Task UpdateAsync(T entity);
    Task DeleteAsync(Guid id);
    Task SaveChangesAsync();
}