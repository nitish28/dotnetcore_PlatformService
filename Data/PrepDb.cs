using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Models;

namespace PlatformService.Data{

public static class PrepDB
{

public static void PrePopulation(IApplicationBuilder app)
{
     using(var serviceScope = app.ApplicationServices.CreateScope())
     {
         SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
     }
}
private static void SeedData(AppDbContext context)
{
  if(!context.Platforms.Any())
  {
        Console.WriteLine("Seeding Data");
        context.AddRange( new Platform(){ Name=".net", Publisher="MS", Cost="free"},
                    new Platform(){ Name=".net core", Publisher="MS", Cost="free"},
                    new Platform(){ Name=".net f", Publisher="MS", Cost="free"});
        context.SaveChanges();
  }
  else
  {
      Console.WriteLine("No data to seed");
  }
}
}



}