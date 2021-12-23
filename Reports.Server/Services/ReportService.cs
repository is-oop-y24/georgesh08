using Reports.Server.Database;

namespace Reports.Server.Services
{
    public class ReportService : IReportService
    {
        private IDatabaseContext _databaseContext;

        public ReportService(IDatabaseContext context)
        {
            _databaseContext = context;
        }
        public string GetAll()
        {
            string query = "SELECT * FROM Reports AS TEXT";
            return _databaseContext.ExecuteReader(query);
        }

        public string GetByEmployee(string employeeId)
        {
            string query = $"SELECT * FROM Reports AS TEXT WHERE ResponsibleEmployee='{employeeId}'";
            return _databaseContext.ExecuteReader(query);
        }

        public void UpdateInstance(string newInstance, string id)
        {
            string query = $"UPDATE Tasks SET Instance='{newInstance}' WHERE ResponsibleEmployee='{id}'";
            _databaseContext.ExecuteCommand(query);
        }

        public void UpdateRelatedTask(string newTask, string id)
        {
            string query = $"UPDATE Tasks SET RelatedTask='{newTask}' WHERE ResponsibleEmployee='{id}'";
            _databaseContext.ExecuteCommand(query);
        }
    }
}