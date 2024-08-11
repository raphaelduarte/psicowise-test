using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Psicowise.Infrastructure.Contexts;

public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        // Obter o diretório do projeto de infraestrutura
        var currentDir = Directory.GetCurrentDirectory();
        
        // Navegar para o diretório da solução
        var solutionDir = Directory.GetParent(currentDir)?.FullName ?? throw new InvalidOperationException("Não foi possível encontrar o diretório da solução.");
        
        // Caminho para o arquivo appsettings.json no projeto principal
        var configPath = Path.Combine(solutionDir, "Psicowise", "appsettings.json");

        // Verificar se o arquivo existe
        if (!File.Exists(configPath))
        {
            throw new FileNotFoundException($"O arquivo de configuração não foi encontrado em {configPath}");
        }

        var configuration = new ConfigurationBuilder()
            .SetBasePath(solutionDir)
            .AddJsonFile(configPath, optional: false, reloadOnChange: true)
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("A string de conexão 'DefaultConnection' não foi encontrada no arquivo de configuração.");
        }

        optionsBuilder.UseNpgsql(connectionString);

        return new DataContext(optionsBuilder.Options);
    }
}