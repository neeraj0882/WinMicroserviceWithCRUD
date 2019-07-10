using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using System.Diagnostics;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateWebHostBuilder(args).Build().Run();
            if (Debugger.IsAttached)
            {
                BuildWebHost(args).Run();
            }
            else
            {
                BuildWebHost(args).RunAsService();
            }
        }

        //public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args)
        //        .UseStartup<Startup>();
        public static IWebHost BuildWebHost(string[] args)
        {
            var hosturl = "http://0.0.0.0:4000";



            IWebHostBuilder hostBuilder = WebHost.CreateDefaultBuilder(args);

            if (Debugger.IsAttached)
            {
                return WebHost.CreateDefaultBuilder(args)
                        .UseUrls(hosturl)
                        .UseStartup<Startup>()
                        .Build();
            }

            var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
            var pathToContentRoot = Path.GetDirectoryName(pathToExe);

            return hostBuilder
                .UseContentRoot(pathToContentRoot)
                .UseUrls(hosturl)
                .UseStartup<Startup>()
                .Build();
        }
    }
}
