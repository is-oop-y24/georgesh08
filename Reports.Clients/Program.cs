using System;
using Reports.Clients.Services;

namespace Reports.Clients
{
    class Program
    {
        static void Main(string[] args)
        {
            ReportsService service = new ReportsService();
            service.CreateEmployee("George");
        }
    }
}