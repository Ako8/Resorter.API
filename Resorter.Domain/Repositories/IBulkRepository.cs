namespace Resorter.Domain.Repositories;

public interface IBulkRepository<T> where T : class
{
    Task<IReadOnlyList<T>> GetAllAsync();
    Task AddAllAsync(IEnumerable<T> objs);
    Task DeleteAllAsync(IEnumerable<T> objs);
    Task SaveChanges();
}
