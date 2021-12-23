using Microsoft.AspNetCore.Mvc;
using Reports.Server.Database;
using Reports.Server.Services;

namespace Reports.Server.Controllers
{
    [ApiController]
    [Route("/report")]
    public class ReportController
    {
        private ReportService _service = new ReportService();
        [HttpGet]
        public string Get([FromQuery] bool getAll = false, [FromQuery] string responsibleEmployee = null)
        {
            if (getAll)
            {
                _service.GetAllReports();
            }

            if (!string.IsNullOrEmpty(responsibleEmployee))
            {
                _service.GetByEmployee(responsibleEmployee);
            }

            return null;
        }

        [HttpPut]
        public void Update([FromQuery] string newInstance = null, [FromQuery] string relatedTaskId = null,
            [FromQuery] string employee = null)

        {
            if (!(string.IsNullOrEmpty(newInstance) && string.IsNullOrEmpty(employee)))
            {
                _service.UpdateReportInstance(newInstance, employee);
            }

            if (!(string.IsNullOrEmpty(relatedTaskId) && string.IsNullOrEmpty(employee)))
            {
                _service.UpdateRelatedTask(relatedTaskId, employee);
            }
        }
    }
}