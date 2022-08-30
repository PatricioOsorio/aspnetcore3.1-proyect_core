using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProjectCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCore
{
  public class Program
  {
    //public static void Main(string[] args)
    //{
    //  var host = BuildWebHost(args);

    //  using (var scope = host.Services.CreateScope())
    //  {
    //    var services = scope.ServiceProvider;
    //    try
    //    {
    //      DbInitializer.CreateUserRoles(services).Wait();
    //    }
    //    catch (Exception ex)
    //    {
    //      var logger = services.GetRequiredService<ILogger<Program>>();
    //      logger.LogError(ex, "A ocurrido un error mientras se enviaba a la Base de datos");
    //    }
    //  }

    //  host.Run();
    //}

    //public static IWebHost BuildWebHost(string[] args) =>
    //  WebHost.CreateDefaultBuilder(args)
    //    .UseStartup<Startup>()
    //    .Build();
    public static void Main(string[] args)
    {
      CreateWebHostBuilder(args).Build().Run();
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
      WebHost.CreateDefaultBuilder(args)
      .UseStartup<Startup>();
  }
}
