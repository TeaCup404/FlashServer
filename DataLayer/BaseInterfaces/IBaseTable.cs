using Microsoft.EntityFrameworkCore;

namespace FlashServer.DataLayer.BaseInterfaces
{
    public interface IBaseTable<TEntity>: IBase<TEntity> where TEntity : class
    {
        public TEntity AddEntity(TEntity entity, DbContext context);

        public TEntity AddEntity(TEntity entity);

        public void UpdateEntity(TEntity entity, DbContext context);

        public void UpdateEntity(TEntity entity);

        public void DeleteEntity(object ID, DbContext context);

        public void DeleteEntity(TEntity entity); 
    }
}