using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Calculadora.Api.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(s => 
            {
                s.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "SoftPlan Test API",
                    Description = "Teste de desenvolvimento",
                    Contact = new Contact { Name = "Alvaro Kramer", Email = "alvarokramer@gmail.com" }                    
                });
            });
        }
    }
}
