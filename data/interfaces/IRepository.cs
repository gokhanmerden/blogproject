using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace data.interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {

        IQueryable<TEntity> GetQuery();
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        void Remove(TEntity entity);
        void Save();
    }
}