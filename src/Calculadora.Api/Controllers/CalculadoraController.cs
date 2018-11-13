using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoftPlanTest.Domain.Calculadora.Commands;
using SoftplanTeste.Domain.Common.Notifications;

namespace Calculadora.Api.Controllers
{    
    [ApiController]
    public class CalculadoraController : BaseController
    {
        private readonly IMediator _mediator;        

        public CalculadoraController(INotificationHandler<DomainNotification> notifications, IMediator mediator) : base(notifications)
        {
            _mediator = mediator;            
        }        

        [HttpGet]
        [Route("calculadora/calcularjuroscompostos")]
        public IActionResult CalcularJuroComposto(decimal valorInicial, int meses)
        {
            var command = new CalcularJuroCompostoCommand(valorInicial, meses);

            return Response(_mediator.Send<decimal>(command).Result.ToString("0.00"));
        }
    }
}
