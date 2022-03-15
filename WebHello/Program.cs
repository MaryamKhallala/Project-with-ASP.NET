using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog.AspNetCore;
using Serilog.Sinks.File;
using Serilog;


namespace WebHello
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Debug()
                .WriteTo.File("Serilogs.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger(); 
            try
            {
                Log.Information("Starting Host "); 
                var host = CreateHostBuilder(args).Build();
                CreateDbIfNotExists(host);
                host.Run();
            }
            catch (Exception e)
            {
                Log.Fatal("Host terminated: " + e); 
            }

            
        }



        private static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<Program>>();
                try
                {
                    var context = services.GetRequiredService<DataContext>();
                    context.Database.EnsureCreated();
                    logger.LogInformation("Db is created succefully");
                }
                catch (Exception ex)
                {          
                    logger.LogError(ex, "An error occurred created the DB"); 
                }
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


    }
}
