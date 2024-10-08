﻿using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        public IGenericRepository<T> Repository<T>() where T : BaseEntity;
        public Task<int> CompleteAsync();
    }
}