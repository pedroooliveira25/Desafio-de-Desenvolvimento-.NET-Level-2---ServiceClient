public interface ICrudRepository<T>
{
    Task AddAsync();
    Task<T> GetByIdAsync();
    Task UpdateAsync();
    Task DeleteAsync();
    Task SaveChangesAsync();
  
}