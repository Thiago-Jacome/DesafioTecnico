using DesafioTecnico.Database;
using DesafioTecnico.Repositories.Implementacoes;
using DesafioTecnico.Repositories.Interfaces;
using DesafioTecnico.Services.Implementacoes;
using DesafioTecnico.Services.Interfaces;

namespace DesafioTecnico.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<MySqlConnectionFactory>();

        services.AddScoped<ICursoRepository, CursoRepository>();
        services.AddScoped<ICursoService, CursoService>();

        services.AddScoped<IProfessorRepository, ProfessorRepository>();
        services.AddScoped<IProfessorService, ProfessorService>();
        
        return services;
    }
}
