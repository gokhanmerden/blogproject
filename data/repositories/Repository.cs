using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data.interfaces;
using Microsoft.EntityFrameworkCore;

namespace data.repositories
{
    public class Repository<TEntity> :IRepository<TEntity>  where TEntity: class{
        private DbSet<TEntity> DbSet;
        private DbContext context;
        public Repository(DbContext context) {
            this.context = context;
            this.DbSet = context.Set<TEntity>();
        }
        public TEntity Add(TEntity entity)
        {
           DbSet.Add(entity);
           return entity;
        }

        public IQueryable<TEntity> GetQuery()
        {
            return DbSet.AsQueryable();
        }

        public void Remove(TEntity entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            DbSet.Remove(entity);
        }

        public TEntity Update(TEntity entity)
        {
            DbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public void Save(){
          context.SaveChanges();
        } 
        public DbSet<TEntity> getDbSet() {
            return DbSet;
        }
    }
}