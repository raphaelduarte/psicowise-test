using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Psicowise.Infrastructure.Contexts;

public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        // Obter o caminho do diretório do projeto principal
        var basePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\Psicowise"));
            
        // Procurar o arquivo appsettings.json
        var configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json")
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseNpgsql(connectionString);

        return new DataContext(optionsBuilder.Options);
    }
}