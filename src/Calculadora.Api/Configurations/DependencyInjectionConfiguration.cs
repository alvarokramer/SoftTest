using Microsoft.Extensions.DependencyInjection;
using SoftPlanTest.Infra.CrossCutting.IoC;

namespace Calculadora.Api.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDIConfiguration(this IServiceCollection services)
        {
            NativeInjector.RegisterServices(services);
        }
    }
}
