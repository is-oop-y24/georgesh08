using System;

namespace Reports.DAL.Entities
{
    
    public class Report
    {
        public Report() { }

        public Report(string responsibleEmployeeId, string reportInstance)
        {
            ReportInstance = reportInstance;
            ResponsibleEmployeeId = responsibleEmployeeId;
        }

        public bool IsClosed { get; set; } = false;
        public string RelatedTask { get; set; } = Guid.Empty.ToString();
        public string ReportInstance { get; set; }
        public string ResponsibleEmployeeId { get; set; } = Guid.Empty.ToString();
    }
}