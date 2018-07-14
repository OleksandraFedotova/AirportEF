using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Domain.Repositiories
{
    public interface IRepository<TEntity>
  where TEntity : IEntity
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetById(Guid id);

        Task Create(TEntity entity);

        Task Update(TEntity entity);

        Task Delete(Guid id);
    }
}
