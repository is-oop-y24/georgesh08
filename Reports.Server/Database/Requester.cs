using Reports.DAL.Entities;

namespace Reports.Server.Database
{
    public class Requester
    {
        private IDatabaseContext _dbContext;

        public Requester(IDatabaseContext context)
        {
            _dbContext = context;
        }

        public string GetAllEmployees()
        {
            string query = "SELECT * FROM Employees AS TEXT";
            return _dbContext.ExecuteReader(query);
        }

        public string GetEmployeeById(string id)
        {
            string query = $"SELECT * FROM Employees AS TEXT WHERE Id='{id}'";
            return _dbContext.ExecuteReader(query);
        }

        public void CreateEmployee(string name)
        {
            var newEmployee = new Employee(name);
            string query = $"INSERT INTO Employees VALUES ('{newEmployee.Id}', '{newEmployee.Name}', '{newEmployee.MasterId}');";
            _dbContext.ExecuteCommand(query);
        }

        public void DeleteEmployee(string id)
        {
            string query = $"DELETE FROM Employees WHERE Id='{id}'";
            _dbContext.ExecuteCommand(query);
        }

        public void UpdateEmployee(string id, string newName, string newMaster)
        {
            string query =
                "UPDATE Employees" +
                $"SET Name='{newName}', MasterId='{newMaster}'" +
                $"WHERE Id='{id}'";
            _dbContext.ExecuteCommand(query);
        }
        
        public string GetAllReports()
        {
            string query = "SELECT * FROM Reports AS TEXT";
            return _dbContext.ExecuteReader(query);
        }

        public string GetByEmployee(string employeeId)
        {
            string query = $"SELECT * FROM Reports AS TEXT WHERE ResponsibleEmployee='{employeeId}'";
            return _dbContext.ExecuteReader(query);
        }

        public void UpdateReportInstance(string newInstance, string id)
        {
            string query = $"UPDATE Tasks SET Instance='{newInstance}' WHERE ResponsibleEmployee='{id}'";
            _dbContext.ExecuteCommand(query);
        }

        public void UpdateRelatedTask(string newTask, string id)
        {
            string query = $"UPDATE Tasks SET RelatedTask='{newTask}' WHERE ResponsibleEmployee='{id}'";
            _dbContext.ExecuteCommand(query);
        }
        
        public void CreateTask(string instance)
        {
            var newTask = new Task(instance);
            string query =
                $"INSERT INTO Tasks " +
                $"VALUES " +
                $"('{newTask.TaskId}', '{newTask.ResponsibleEmployee}', '{instance}', '{newTask.CreationTime.ToString()}', '{newTask.LastChangeTime.ToString()}', '{newTask.Status}')";
            _dbContext.ExecuteCommand(query);
        }

        public string GetByCreationTime(string time)
        {
            string query = $"SELECT * FROM Tasks AS TEXT WHERE CreationTime='{time}'";
            return _dbContext.ExecuteReader(query);
        }

        public string GetTasksWithChanges()
        {
            string query = $"SELECT * FROM Tasks AS TEXT WHERE IsChanged=1";
            return _dbContext.ExecuteReader(query);
        }

        public void UpdateTaskEmployee(string taskId, string employeeId)
        {
            string query = $"UPDATE Tasks SET ResponsibleEmployee='{employeeId}' WHERE Id='{taskId}'";
            _dbContext.ExecuteCommand(query);
        }

        public string GetTaskById(string taskId)
        {
            string query = $"SELECT * FROM Tasks AS TEXT WHERE Id='{taskId}'";
            return _dbContext.ExecuteReader(query);
        }

        public string GetAllTasks()
        {
            string query = "SELECT * FROM Tasks AS TEXT";
            return _dbContext.ExecuteReader(query);
        }
    }
}