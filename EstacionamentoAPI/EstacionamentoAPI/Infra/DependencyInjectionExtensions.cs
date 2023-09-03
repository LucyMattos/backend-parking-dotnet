using EstacionamentoAPI.Repository.Contratos;
using EstacionamentoAPI.Repository.Repositorios;
using EstacionamentoAPI.Services;
using EstacionamentoAPI.Services.Contratos;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace EstacionamentoAPI.Infra
{
    public static class DependencyInjectionExtensions
    {
        public static string PolicyName => "Estacionamento_Cors";

        public static void AddDIServices(this IServiceCollection services)
        {
            AddServices(services);
            AddRepositories(services);
            AddCoreCors(services);
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IVeiculoServico, VeiculoServico>();
            services.AddTransient<IEmpresaServico, EmpresaServico>();
            services.AddScoped<INotificationService, NotificationService>();
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepositorio<>), typeof(Repositorio<>));
            services.AddTransient<IEmpresaRepositorio, EmpresaRepositorio>();
            services.AddTransient<IVeculoRepositorio, VeiculoRepositorio>();
        }

        public static IApplicationBuilder UseCoreCors(this IApplicationBuilder app)
        {
            return app.UseCors(PolicyName);
        }

        private static IServiceCollection AddCoreCors(this IServiceCollection services)
        {
            return services.AddCors(delegate (CorsOptions options)
            {
                options.AddPolicy(PolicyName, delegate (CorsPolicyBuilder p)
                {
                    p.AllowAnyOrigin();
                    p.AllowAnyMethod();
                    p.AllowAnyHeader();
                });
            });
        }
    }
}
