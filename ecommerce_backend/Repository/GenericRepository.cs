﻿using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Repository.Store;

namespace Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _storeContext;

        public GenericRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _storeContext.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _storeContext.Set<T>().FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _storeContext.Set<T>().AddAsync(entity);
        }

        public void DeleteAsync(T entity)
        {
            _storeContext.Set<T>().Remove(entity);
        }

        public void UpdateAsync(T entity)
        {
            _storeContext.Set<T>().Update(entity);
        }
    }
}