using Microsoft.Extensions.DependencyInjection;
using MediatR;
using SoftPlanTest.Domain.Calculadora.Commands;
using SoftPlanTest.Domain.Calculadora.Handlers;
using SoftplanTeste.Domain.Common.Notifications;

namespace SoftPlanTest.Infra.CrossCutting.IoC
{
    public class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain - Commands
            services.AddScoped<IRequestHandler<CalcularJuroCompostoCommand, decimal>, CalculadoraCommandHandler>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
        }
    }
}
