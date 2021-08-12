using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArenaTelegramBotAzure.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ArenaTelegramBotAzure.DAL
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;
        public Repository(BotContext context)
        {
            _dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> Get(long Id)
        {
            return await _dbSet.FindAsync(Id);
        }

        public async Task Add(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public Task Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet.AsQueryable();
        }
    }
}
