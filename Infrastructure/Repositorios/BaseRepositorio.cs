using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Repositorios;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositorios
{
    public class BaseRepositorio<TEntity> : IBaseRepositorio<TEntity> where TEntity : class
    {
        internal AppDbContext Context;
        internal DbSet<TEntity> dbSet;

        public Task AddAsync(TEntity entidad)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask<TEntity> GetByIdAsync()
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity entidad)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<TEntity> entidades)
        {
            throw new NotImplementedException();
        }

        public Task Update(TEntity entidad)
        {
            throw new NotImplementedException();
        }
    }
}