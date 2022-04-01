using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace assignment1
{
    public class Program
    {
        public static IDictionary<string, string> envVars = new Dictionary<string, string>();

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(
                webBuilder => {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
