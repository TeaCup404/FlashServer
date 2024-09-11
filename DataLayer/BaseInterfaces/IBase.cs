using Microsoft.EntityFrameworkCore;

namespace FlashServer.DataLayer.BaseInterfaces
{
    public interface IBase<TEntity> where TEntity : class
    {
        public TEntity GetEntityByID(object ID, DbContext context);
        
        public TEntity GetEntityByID(object ID);

        public List<TEntity> GetAllEntities(DbContext context);

        public List<TEntity> GetAllEntities();
    }
}
