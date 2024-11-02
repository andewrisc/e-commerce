using System;
using Core.Entities;

namespace Core.Interface;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(int id);
    Task<IReadOnlyList<T>> ListAllAsync();
    Task<T?> GetEntityWithSpec(ISpesification<T> spec);
    Task<IReadOnlyList<T>> ListAsync(ISpesification<T> spec);

    Task<TResult?> GetEntityWithSpec<TResult>(ISpesification<T, TResult> spec);
    Task<IReadOnlyList<TResult>> ListAsync<TResult>(ISpesification<T, TResult> spec);

    void Add(T entity);
    void Update(T entity);
    void Remove(T entity);
    Task<bool> SaveAllAsync();
    bool Exist(int id);
}
