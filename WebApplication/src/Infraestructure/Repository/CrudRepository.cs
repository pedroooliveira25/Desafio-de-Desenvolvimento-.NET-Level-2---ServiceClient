using MongoDB.Driver;

public class CrudRepository<T> : ICrudRepository<T> where T : class
{
    private readonly IMongoCollection<T> _collection;

    public CrudRepository(IMongoDatabase database)
    {
        _collection = database.GetCollection<T>(typeof(T).Name);
    }

    public async Task AddAsync(T entity)
    {
        await _collection.InsertOneAsync(entity);
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        
        var filter = Builders<T>.Filter.Eq("Id", id);

        return await _collection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        var id = entity.GetType().GetProperty("Id")?.GetValue(entity);

        var filter = Builders<T>.Filter.Eq("Id", id);

        await _collection.ReplaceOneAsync(filter, entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        var filter = Builders<T>.Filter.Eq("Id", id);

        await _collection.DeleteOneAsync(filter);
    }

    public Task SaveChangesAsync()
    {
        return Task.CompletedTask;
    }
}