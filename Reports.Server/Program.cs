using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Reports.Server.Database;

namespace Reports.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            DatabaseInitializer.GetInstance()
                .InitDatabaseContext(new LocalDatabaseContext("C:\\Users\\geo02\\Desktop\\Db\\reportsDb.db"));
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}