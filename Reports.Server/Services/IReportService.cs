namespace Reports.Server.Services
{
    public interface IReportService
    {
        string GetAllReports();
        string GetByEmployee(string employeeId);
        void UpdateReportInstance(string newInstance, string id);
        void UpdateRelatedTask(string newTask, string id);
    }
}