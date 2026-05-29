public interface ICrudRepository<T>
{
    Task AddAsync();
    Task<T> GetByIdAsync(Guid id);
    Task UpdateAsync();
    Task DeleteAsync(T entity);
    Task SaveChangesAsync();
}