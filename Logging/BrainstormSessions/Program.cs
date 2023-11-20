using System;
using System.Collections.Immutable;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.EmailPickup;
using log4net;
namespace BrainstormSessions
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.File("file.txt", rollingInterval:RollingInterval.Day)
                .WriteTo.EmailPickup(
                    fromEmail: "app@example.com",
                    toEmail: "andjic.djordje99@gmail.com",
                    pickupDirectory: @"./",
                    subject: "UH OH",
                    fileExtension: ".email",
                    restrictedToMinimumLevel: LogEventLevel.Information)
                .CreateLogger();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).ConfigureLogging(builder=>{
            log4net.Config.BasicConfigurator.Configure();
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(Program));
                });
            
    }
}
