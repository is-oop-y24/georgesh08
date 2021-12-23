using Microsoft.Data.Sqlite;
using Reports.DAL.Entities;

namespace Reports.Server.Services
{
    public interface IEmployeeService
    {
        string GetAll();
        string GetById(string id);
        void Create(string name);
        void Delete(string id);
        void Update(string id,  string newName, string newMaster);
    }
}