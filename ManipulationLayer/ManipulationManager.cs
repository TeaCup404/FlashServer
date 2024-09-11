using AutoMapper;
using FlashServer.DataLayer.BaseInterfaces;
using Microsoft.EntityFrameworkCore;

namespace FlashServer.ManipulationLayer
{
    public class ManipulationManager<OutEntity, InEntity, DataEntity, Context> : IManipulationManager<OutEntity, InEntity, DataEntity>, IBasic
        where OutEntity : class where InEntity : class where DataEntity : class where Context : DbContext
    {
        public readonly IDbContextFactory<Context> _contextFactory;
        public readonly IMapper _mapper;
        private readonly IBaseTable<DataEntity> _baseTable;

        public ManipulationManager(IDbContextFactory<Context> context, IBaseTable<DataEntity> baseTable, IMapper mapper) {
            _contextFactory = context;
            _mapper = mapper;
            _baseTable = baseTable;        
        }

        public virtual bool createEntity(InEntity entity)
        {
            using(var context = _contextFactory.CreateDbContext())
            {
                DataEntity data = _mapper.Map<InEntity, DataEntity>(entity);

                _baseTable.AddEntity(data,context);
            }

            return true;
        }

        public virtual bool deleteEntity(object ID)
        {
            using(var context = _contextFactory.CreateDbContext())
            {
                _baseTable.DeleteEntity(ID,context);
            }

            return true;
        }

        public virtual List<OutEntity> getAllEntities()
        {
            using(var context = _contextFactory.CreateDbContext())
            {
                return TransformFromData(_baseTable.GetAllEntities(context));
            }
        }

        public virtual OutEntity getByID(object ID)
        {
            using(var context = _contextFactory.CreateDbContext())
            {
                DataEntity data = _baseTable.GetEntityByID(ID, context);

                return TransformFromData(data);
            }
        }

        public virtual OutEntity TransformFromData(DataEntity dataEntity)
        {
            return _mapper.Map<DataEntity, OutEntity>(dataEntity);
        }
        public virtual List<OutEntity> TransformFromData(List<DataEntity> dataEntities)
        {
            return _mapper.Map<List<DataEntity>, List<OutEntity>>(dataEntities);
        }

        public virtual TransformEntity TransformFromData<TransformEntity>(DataEntity dataEntity) where TransformEntity : class
        {
            return _mapper.Map<DataEntity, TransformEntity>(dataEntity);
        }

        public virtual bool updateEntity(InEntity entity)
        {
            using(var context = _contextFactory.CreateDbContext())
            {
                DataEntity data = _mapper.Map<InEntity, DataEntity>(entity);

                _baseTable.AddEntity(data,context);
            }

            return true;
        }
    }
}