using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SoftTest.CalculadoraJuros.Data;
using SoftTest.CalculadoraJuros.Domain;
using SoftTest.Shared.Notifications;

namespace SoftTest.CalculadoraJuros.Api.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            services.AddScoped<ICalculoJuroCompostoService, CalculoJuroCompostoService>();
            services.AddScoped<ICalculadoraRepository, CalculadoraRepository>();            
        }
    }
}
