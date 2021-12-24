using Microsoft.Data.Sqlite;
using Reports.DAL.Entities;

namespace Reports.Server.Services
{
    public interface IEmployeeService
    {
        string GetAllEmployees();
        string GetEmployeeById(string id);
        void CreateEmployee(string name);
        void DeleteEmployee(string id);
        void UpdateEmployee(string id, string newName, string newMaster);
    }
}