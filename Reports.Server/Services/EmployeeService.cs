using Reports.DAL.Entities;
using Reports.Server.Database;

namespace Reports.Server.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IDatabaseContext _dbContext;

        public EmployeeService(IDatabaseContext context)
        {
            _dbContext = context;
        }

        public string GetAll()
        {
            string query = "SELECT * FROM Employees AS TEXT";
            return _dbContext.ExecuteReader(query);
        }

        public string GetById(string id)
        {
            string query = $"SELECT * FROM Employees AS TEXT WHERE Id='{id}'";
            return _dbContext.ExecuteReader(query);
        }

        public void Create(string name)
        {
            var newEmployee = new Employee(name);
            string query = $"INSERT INTO Employees VALUES ('{newEmployee.Id}', '{newEmployee.Name}', '{newEmployee.MasterId}');";
            _dbContext.ExecuteCommand(query);
        }

        public void Delete(string id)
        {
            string query = $"DELETE FROM Employees WHERE Id='{id}'";
            _dbContext.ExecuteCommand(query);
        }

        public void Update(string id, string newName, string newMaster)
        {
            string query =
                "UPDATE Employees" +
                $"SET Name='{newName}', MasterId='{newMaster}'" +
                $"WHERE Id='{id}'";
            _dbContext.ExecuteCommand(query);
        }
    }
}