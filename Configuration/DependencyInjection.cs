
using DesafioTecnico.Repositories.Implementacoes;
using DesafioTecnico.Repositories.Interfaces;
using Org.BouncyCastle.Tls;
using System.Runtime.CompilerServices;

namespace DesafioTecnico.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddAplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ICursoRepository, CursoRepository>();
        services.AddScoped<IProfessorRepository, ProfessorRepository>();
        return services;
    }
}
