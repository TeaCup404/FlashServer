using FlashServer.DataLayer.BaseInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FlashServer.DataLayer.BaseDataControllers
{
    public class BaseTable<TEntity, context> : IBaseTable<TEntity> where TEntity : class where context : DbContext
    {
        public readonly IDbContextFactory<context> _contextFactory;

        public BaseTable() {}

        public BaseTable(IDbContextFactory<context> context) 
        {
            _contextFactory = context;
        }

        public virtual TEntity GetEntityByID(object ID, DbContext context)
        {
            return context.Set<TEntity>().Find(ID);
        }

        public virtual TEntity GetEntityByID(object ID)
        {
            if(_contextFactory == null)
            { throw new Exception("this cannot be called without contextFactory"); }

            using (var context = _contextFactory.CreateDbContext())
            {
                return GetEntityByID(ID, context);
            }
        }

        public virtual List<TEntity> GetAllEntities(DbContext context)
        {
            return context.Set<TEntity>().AsNoTracking().ToList();
        }

        public virtual List<TEntity> GetAllEntities()
        {
            if(_contextFactory == null)
            { throw new Exception("this cannot be called without contextFactory"); }

            using (var context = _contextFactory.CreateDbContext())
            {
                return GetAllEntities(context);
            }
        }

        public virtual TEntity AddEntity(TEntity entity ,DbContext context)
        {
            EntityEntry<TEntity> entityEntry = context.Set<TEntity>().Add(entity);
            context.SaveChanges();
            return entityEntry.Entity;
        }

        public virtual TEntity AddEntity(TEntity entity)
        {
            if(_contextFactory == null)
            { throw new Exception("this cannot be called without contextFactory"); }

            using (var context = _contextFactory.CreateDbContext())
            {
                return AddEntity(entity ,context);
            }
        }

        public virtual void UpdateEntity(TEntity entity ,DbContext context)
        {
            context.Set<TEntity>().Update(entity);
            context.SaveChanges();
        }

        public virtual void UpdateEntity(TEntity entity)
        {
            if(_contextFactory == null)
            { throw new Exception("this cannot be called without contextFactory"); }

            using (var context = _contextFactory.CreateDbContext())
            {
                UpdateEntity(entity ,context);
            }
        }

        public virtual void DeleteEntity(object ID ,DbContext context)
        {
            TEntity entity =  context.Set<TEntity>().Find(ID);
            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();
        }

        public virtual void DeleteEntity(TEntity entity)
        {
            if(_contextFactory == null)
            { throw new Exception("this cannot be called without contextFactory"); }

            using (var context = _contextFactory.CreateDbContext())
            {
                DeleteEntity(entity ,context);
            }
        }
    }
}