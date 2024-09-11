using Microsoft.EntityFrameworkCore;

namespace FlashServer.DataLayer.BaseInterfaces
{
    public interface IBaseView<TEntity>: IBase<TEntity> where TEntity : class
    {
        public TEntity GetByProperty(object value, DbContext context, string propertyName);
    }
}