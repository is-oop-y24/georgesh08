using Reports.DAL.Entities;
using Reports.Server.Database;

namespace Reports.Server.Services
{
    public class TaskService : ITaskService
    {
        private IDatabaseContext _databaseContext;

        public TaskService(IDatabaseContext context)
        {
            _databaseContext = context;
        }
        public void CreateTask(string instance)
        {
            var newTask = new Task(instance);
            string query =
                $"INSERT INTO Tasks " +
                $"VALUES " +
                $"('{newTask.TaskId}', '{newTask.ResponsibleEmployee}', '{instance}', '{newTask.CreationTime.ToString()}', '{newTask.LastChangeTime.ToString()}', '{newTask.Status}')";
            _databaseContext.ExecuteCommand(query);
        }

        public string GetByCreationTime(string time)
        {
            string query = $"SELECT * FROM Tasks AS TEXT WHERE CreationTime='{time}'";
            return _databaseContext.ExecuteReader(query);
        }

        public string GetTasksWithChanges()
        {
            string query = $"SELECT * FROM Tasks AS TEXT WHERE IsChanged=1";
            return _databaseContext.ExecuteReader(query);
        }

        public void UpdateTaskEmployee(string taskId, string employeeId)
        {
            string query = $"UPDATE Tasks SET ResponsibleEmployee='{employeeId}' WHERE Id='{taskId}'";
            _databaseContext.ExecuteCommand(query);
        }

        public string GetTaskById(string taskId)
        {
            string query = $"SELECT * FROM Tasks AS TEXT WHERE Id='{taskId}'";
            return _databaseContext.ExecuteReader(query);
        }

        public string GetAll()
        {
            string query = "SELECT * FROM Tasks AS TEXT";
            return _databaseContext.ExecuteReader(query);
        }
    }
}