namespace Reports.Server.Services
{
    public interface IReportService
    {
        string GetAll();
        string GetByEmployee(string employeeId);
        void UpdateInstance(string newInstance, string id);
        void UpdateRelatedTask(string newTask, string id);
    }
}