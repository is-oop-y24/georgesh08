using Microsoft.AspNetCore.Mvc;
using Reports.Server.Services;

namespace Reports.Server.Controllers
{
    [ApiController]
    [Route("/employee")]
    public class EmployeeController : ControllerBase
    {
        private EmployeeService _service = new EmployeeService();
        
        [HttpGet]
        public string Get([FromQuery] string id = null, [FromQuery] bool getAll = false)
        {
            if (getAll)
            {
                return _service.GetAll();
            }

            if (!string.IsNullOrEmpty(id))
            {
                _service.GetById(id);
            }

            return null;
        }

        [HttpPost]
        public void CreateEmployee([FromQuery] string name)
        {
            if(!string.IsNullOrWhiteSpace(name))
            {
                _service.Create(name);
            }
        }

        [HttpDelete]
        public void Delete([FromQuery] string id)
        {
            _service.Delete(id);
        }

        [HttpPut]
        public void Update([FromQuery] string id, [FromQuery] string newName, [FromQuery] string newMaster)
        {
            _service.Update(id, newName, newMaster);
        }
    }
}