using MediatR;
using SoftPlanTest.Domain.Calculadora.Commands;
using SoftplanTeste.Domain.Common.Notifications;
using System.Threading;
using System.Threading.Tasks;
using SoftPlanTest.Domain.Handlers;

namespace SoftPlanTest.Domain.Calculadora.Handlers
{
    public class CalculadoraCommandHandler : BaseCommandHandler, IRequestHandler<CalcularJuroCompostoCommand, decimal>
    {
        public CalculadoraCommandHandler(IMediator mediator) : base(mediator)
        {
        }

        public Task<decimal> Handle(CalcularJuroCompostoCommand request, CancellationToken cancellationToken)
        {
            var calculoJuroComposto = new CalculoJuroComposto(request.ValorInicial, request.Meses);

            if (calculoJuroComposto.IsValid())
                return Task.FromResult(calculoJuroComposto.Calcular());

            NotificarValidacoesErro(calculoJuroComposto.ValidationResult);
            return Task.FromResult<decimal>(0);
        }        
    }
}
