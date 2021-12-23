using Microsoft.AspNetCore.Mvc;
using Reports.Server.Database;
using Reports.Server.Services;

namespace Reports.Server.Controllers
{
    [ApiController]
    [Route("/task")]
    public class TaskController
    {
        private TaskService _service = new TaskService();
        
        [HttpGet]
        public string Get([FromQuery] bool getAll = false, [FromQuery] string taskId = null, [FromQuery] string creationTime = null,
            [FromQuery] bool isChanged = false)
        {
            if (getAll)
            {
                return _service.GetAllTasks();
            }

            if (!string.IsNullOrEmpty(creationTime))
            {
                _service.GetByCreationTime(creationTime);
            }

            if (isChanged)
            {
                _service.GetTasksWithChanges();
            }

            if (!string.IsNullOrEmpty(taskId))
            {
                _service.GetTaskById(taskId);
            }

            return null;
        }

        [HttpPost]
        public void AddTask([FromQuery] string instance = null)
        {
            if(!string.IsNullOrWhiteSpace(instance))
            {
                _service.CreateTask(instance);
            }
        }

        [HttpPut]
        public void Update([FromQuery] string newEmployeeId = null, [FromQuery] string taskId = null)
        {
            if (!string.IsNullOrEmpty(newEmployeeId))
            {
                _service.UpdateTaskEmployee(taskId, newEmployeeId);
            }
        }
    }
}