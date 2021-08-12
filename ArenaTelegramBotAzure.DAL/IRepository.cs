using System;
using System.Linq;
using System.Threading.Tasks;

namespace ArenaTelegramBotAzure.DAL
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Get(long id);
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(long id);
        IQueryable<TEntity> GetAll();
    }
}
