﻿namespace Resorter.Domain.Repositories;

public interface ICrudRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id);
    Task<IReadOnlyList<T>> GetAllAsync();
    Task AddAsync(T entity);
    Task DeleteAsync(T entity);
    Task SaveChanges();

}
