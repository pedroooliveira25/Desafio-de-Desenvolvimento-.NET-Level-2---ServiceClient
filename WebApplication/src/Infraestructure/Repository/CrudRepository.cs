public class CrudRepository<T> : ICrudRepository<T>
{
    private readonly AppDbContext _context;

    public CrudRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public Task UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        return Task.CompletedTask;
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _context.Set<T>().FindAsync(id);

        if (entity != null)
            _context.Set<T>().Remove(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}