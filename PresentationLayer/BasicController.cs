using FlashServer.ManipulationLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FlashServer.PresentationLayer
{
    public class BasicController<OutEntity, InEntity, DataEntity, Key> : Controller
        where OutEntity : class where InEntity : class where DataEntity : class where Key : class
    {
        public IManipulationManager<OutEntity, InEntity, DataEntity> _manipulationManager;
        public ILogger _logger;

        public BasicController(IManipulationManager<OutEntity, InEntity, DataEntity> manipulationManager, ILogger logger)
        {
            _manipulationManager = manipulationManager;
            _logger = logger;
        }

        [HttpGet]
        [Route("{ID}")]
        public virtual ActionResult<OutEntity> GetByID(Key ID)
        {
            return _manipulationManager.getByID(ID);
        }

        [HttpGet]
        [Route("GetAll")]
        public virtual ActionResult<List<OutEntity>> GetAll()
        {
            return _manipulationManager.getAllEntities();
        }

        [HttpPost]
        [Route("Create")]
        public virtual ActionResult Create(InEntity entity)
        {
            _manipulationManager.createEntity(entity);

            return Ok();
        }

        [HttpPut]
        [Route("Update")]
        public virtual ActionResult Update(InEntity entity)
        {
            _manipulationManager.updateEntity(entity);

            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public virtual ActionResult Delete(Key entity)
        {
            _manipulationManager.deleteEntity(entity);

            return Ok();
        }
    }

    public class BasicController<OutEntity, InEntity, DataEntity> : Controller
        where OutEntity : class where InEntity : class where DataEntity : class
    {
        private IManipulationManager<OutEntity, InEntity, DataEntity> _manipulationManager;
        public ILogger _logger;

        public BasicController(IManipulationManager<OutEntity, InEntity, DataEntity> manipulationManager, ILogger logger)
        {
            _manipulationManager = manipulationManager;
            _logger = logger;
        }

        [HttpGet]
        [Route("{ID}")]
        public virtual ActionResult<OutEntity> GetByID(int ID)
        {
            return _manipulationManager.getByID(ID);
        }

        [HttpGet]
        [Route("GetAll")]
        public virtual ActionResult<List<OutEntity>> GetAll()
        {
            return _manipulationManager.getAllEntities();
        }

        [HttpPost]
        [Route("Create")]
        public virtual ActionResult Create(InEntity entity)
        {
            _manipulationManager.createEntity(entity);

            return Ok();
        }

        [HttpPut]
        [Route("Update")]
        public virtual ActionResult Update(InEntity entity)
        {
            _manipulationManager.updateEntity(entity);

            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public virtual ActionResult Delete(int ID)
        {
            _manipulationManager.deleteEntity(ID);

            return Ok();
        }
    }
}