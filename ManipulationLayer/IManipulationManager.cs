namespace FlashServer.ManipulationLayer
{
    public interface IManipulationManager<OutEntity, InEntity, DataEntity> 
        where OutEntity : class where InEntity : class where DataEntity : class
    {
        public OutEntity getByID(object ID);
        public List<OutEntity> getAllEntities();
        public bool updateEntity(InEntity entity);
        public bool createEntity(InEntity entity);
        public bool deleteEntity(object ID);
        public OutEntity TransformFromData(DataEntity dataEntity);
        public List<OutEntity> TransformFromData(List<DataEntity> dataEntity);
        public TransformEntity TransformFromData<TransformEntity>(DataEntity dataEntity) where TransformEntity : class;
    }
}