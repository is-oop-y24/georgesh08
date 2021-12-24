using Reports.DAL;
using Reports.DAL.Tools;
using Reports.Server.Database;

namespace Reports.Server.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IDatabaseContext _dbContext;
        private Requester _requester = new Requester(DatabaseInitializer.GetInstance().Context);

        public string GetAllEmployees()
        {
            return _requester.GetAllEmployees();
        }

        public string GetEmployeeById(string id)
        {
            return _requester.GetEmployeeById(id);
        }

        public void CreateEmployee(string name)
        {
            _requester.CreateEmployee(name);
        }

        public void DeleteEmployee(string id)
        {
            _requester.DeleteEmployee(id);
        }

        public void UpdateEmployee(string id, string newName, string newMaster)
        {
            _requester.UpdateEmployee(id, newName, newMaster);
        }
    }
}