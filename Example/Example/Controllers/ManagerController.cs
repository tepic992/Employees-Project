using Example.Entities;
using Example.Managers;
using Microsoft.AspNetCore.Mvc;


namespace Example.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManagerController : ControllerBase
    {
        private readonly ManagmentManagers _mng;

        public ManagerController(ManagmentManagers mng)
        {
            _mng = mng;
        }
     
        [HttpGet("{id}")]
        public ActionResult GetManager(long id)
        {
            var manager = _mng.Get(id);
            if (manager == null)
            {
                return NotFound();
            }
            return Ok(manager);
        }

        [HttpGet]
        public ActionResult GetAllManager()
        {
            var result = _mng.GetAll();
            
            return Ok(result);
        }

        [HttpPost]
        public ActionResult PostManager(Manager manager)
        {
            var newManager = _mng.Post(manager);
            if (manager == null)
            {
                return NotFound();
            }

            return Ok(newManager);
        }

        [HttpPut("{id}")]
        public ActionResult PutManager(long id, Manager manager)
        {
            var result = _mng.Put(manager);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public string DeleteManager(long id)
        {
            return _mng.Delete(id);
        }        

    }
}
