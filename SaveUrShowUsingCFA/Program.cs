//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Serilog;
//using Serilog.Events;

//namespace SaveUrShowUsingCFA
//{
//    //public class Program
//    //{
//    //    public static void Main(string[] args)
//    //    {
//    //        CreateHostBuilder(args).Build().Run();
//    //    }

//    //    public static IHostBuilder CreateHostBuilder(string[] args) =>
//    //        Host.CreateDefaultBuilder(args)
//    //            .ConfigureWebHostDefaults(webBuilder =>
//    //            {
//    //                webBuilder.UseStartup<Startup>();
//    //            });
//    //}
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            Log.Logger = new LoggerConfiguration()
//                .MinimumLevel.Debug()
//                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
//                .Enrich.FromLogContext()
//                .WriteTo.Console()
//                .WriteTo.File("D:\\LearnCore\\Log\\ApiLog-.log", rollingInterval: RollingInterval.Day)
//                .CreateLogger();

//            try
//            {
//                CreateHostBuilder(args).Build().Run();
//            }
//            catch (Exception ex)
//            {
//                Log.Fatal(ex, "Host terminated unexpectedly");
//            }
//            finally
//            {
//                Log.CloseAndFlush();
//            }
//        }

//        public static IHostBuilder CreateHostBuilder(string[] args) =>
//            Host.CreateDefaultBuilder(args)
//                .UseSerilog() 
//                .ConfigureWebHostDefaults(webBuilder =>
//                {
//                    webBuilder.UseStartup<Startup>();
//                });
//    }

//}

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using System;

namespace SaveUrShowUsingCFA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File("D:\\LearnCore\\Log\\ApiLog-.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
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

