using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SoftTest.CalculadoraJuros.Domain;
using MediatR;
using SoftTest.Shared.Notifications;

namespace SoftTest.CalculadoraJuros.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class CalculadoraJurosController : ApiControllerBase
    {
        private readonly ICalculoJuroCompostoService _calculoJuroCompostoService;        

        public CalculadoraJurosController(INotificationHandler<DomainNotification> notifications,
                                          ICalculoJuroCompostoService calculoJuroCompostoService) : base(notifications)
        {
            _calculoJuroCompostoService = calculoJuroCompostoService;
        }

        [HttpGet]
        [Route("api/calcularjuros")]
        public async Task<IActionResult> CalcularJuroComposto(decimal valorInicial, int meses)
        {
            var result = await _calculoJuroCompostoService.CalcularJuroComposto(valorInicial, meses);

            return Response(new { juroComposto = result.ToString("0.00") } );
        }
    }
}
