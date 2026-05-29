public interface Crud<T>
{
    Task AddAsync();
    Task<T> GetByIdAsync();
    Task UpdateAsync();
    Task DeleteAsync();
    Task SaveChangesAsync();
  
}