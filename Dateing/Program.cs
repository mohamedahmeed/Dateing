using Dateing.Migrations;
using Dateing.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dateing
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
         var h=  CreateHostBuilder(args).Build();
            var scope = h.Services.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var s = services.GetRequiredService<DatingEntity>();
                await s.Database.MigrateAsync();
                await Seed.setData(s);
            }
            catch (Exception ex)
            {
                var l=services.GetRequiredService<ILogger<Program>>();
                l.LogError(ex, "error");
            }
         await h.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
