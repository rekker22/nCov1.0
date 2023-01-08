using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using nCov1._0.Models;
using Microsoft.AspNetCore;
using nCov1._0;

namespace nCov1._0
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().MigrateDatabase().Run();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        }
    }
}
