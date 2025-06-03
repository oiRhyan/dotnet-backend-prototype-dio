using Microsoft.EntityFrameworkCore;
using minimal_api.Domain.Entitys;

namespace minimal_api.Infra.Db;

public class DatabaseContext : DbContext
{

    private readonly IConfiguration _configurationAppSettings = default!;
    public DatabaseContext(IConfiguration configuration)
    {
        _configurationAppSettings = configuration;
    }

    public DbSet<Adiministrator> Adiministrators { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Adiministrator>().HasData(
              new Adiministrator
              {
                  Id = 1,
                  Email = "administrator@gmail.com",
                  Password = "123456",
                  Profile = "Adm"
              }
        );
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connection = _configurationAppSettings.GetConnectionString("DefaultConnection")?.ToString();
            if (!string.IsNullOrEmpty(connection))
            {
                optionsBuilder.UseSqlServer(connection);
            }
        }
    }

}