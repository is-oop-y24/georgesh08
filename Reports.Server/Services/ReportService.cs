using Reports.Server.Database;

namespace Reports.Server.Services
{
    public class ReportService : IReportService
    {
        private IDatabaseContext _databaseContext;
        private Requester _requester = new Requester(DatabaseInitializer.GetInstance().Context);
        public string GetAllReports()
        {
            return _requester.GetAllReports();
        }

        public string GetByEmployee(string employeeId)
        {
            return _requester.GetByEmployee(employeeId);
        }

        public void UpdateReportInstance(string newInstance, string id)
        {
            _requester.UpdateReportInstance(newInstance, id);
        }

        public void UpdateRelatedTask(string newTask, string id)
        {
            _requester.UpdateRelatedTask(newTask, id);
        }
    }
}