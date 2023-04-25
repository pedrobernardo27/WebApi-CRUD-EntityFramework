using CRUDWebApiEntityFrameworkService.Services;
using CRUDWebApiEntityFrameworkService.Interfaces;
using CRUDWebApiEntityFrameworkRepository.Repository;
using CRUDWebApiEntityFrameworkRepository.Interfaces;

namespace CRUDWebApiEntityFramework.DependencyInjections;
public static class DatabaseExtensions
{
    public static IServiceCollection AddDatabaseExtensions(this IServiceCollection services)
    {
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IPessoaService, PessoaService>();

        services.AddTransient<IEmailRepository, EmailRepository>();
        services.AddTransient<IPessoaRepository, PessoaRepository>();
        services.AddTransient<IEnderecoRepository, EnderecoRepository>();

        return services;
    }
}

