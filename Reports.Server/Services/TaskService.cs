using Reports.DAL.Entities;
using Reports.Server.Database;

namespace Reports.Server.Services
{
    public class TaskService : ITaskService
    {
        private IDatabaseContext _databaseContext;
        private Requester _requester = new Requester(DatabaseInitializer.GetInstance().Context);
        public void CreateTask(string instance)
        {
            _requester.CreateTask(instance);
        }

        public string GetByCreationTime(string time)
        {
            return _requester.GetByCreationTime(time);
        }

        public string GetTasksWithChanges()
        {
            return _requester.GetTasksWithChanges();
        }

        public void UpdateTaskEmployee(string taskId, string employeeId)
        {
            _requester.UpdateTaskEmployee(taskId, employeeId);
        }

        public string GetTaskById(string taskId)
        {
            return _requester.GetTaskById(taskId);
        }

        public string GetAllTasks()
        {
            return _requester.GetAllTasks();
        }
    }
}