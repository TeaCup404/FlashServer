using FlashServer.DataLayer.BaseInterfaces;
using Microsoft.EntityFrameworkCore;

namespace FlashServer.DataLayer.BaseDataControllers
{
    public class BaseView<TEntity, context> : IBaseView<TEntity> where TEntity : class where context : DbContext
    {
        public readonly IDbContextFactory<context> _contextFactory;

        public BaseView() {}

        public BaseView(IDbContextFactory<context> context) 
        {
            _contextFactory = context;
        }

        public virtual TEntity GetEntityByID(object ID, DbContext context)
        {
            return GetByProperty(ID, context);
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
            return context.Set<TEntity>().ToList();
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

        public TEntity GetByProperty(object ID, DbContext context, string propertyName = "ID")
        {
            return context.Set<TEntity>().FirstOrDefault(x => EF.Property<object>(x, propertyName) == ID);
        }
    }
}