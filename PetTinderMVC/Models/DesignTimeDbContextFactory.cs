using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace PetTinderMVC.Models
{
  public class PetTinderMVCContextFactory : IDesignTimeDbContextFactory<PetTinderMVCContext>
  {

    PetTinderMVCContext IDesignTimeDbContextFactory<PetTinderMVCContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<PetTinderMVCContext>();
      var connectionString = configuration.GetConnectionString("DefaultConnection");

      builder.UseMySql(connectionString);

      return new PetTinderMVCContext(builder.Options);
    }
  }
}