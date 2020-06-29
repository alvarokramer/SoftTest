using MediatR;
using System.Threading.Tasks;
using FluentValidation.Results;
using SoftTest.Shared.Notifications;

namespace SoftTest.CalculadoraJuros.Domain
{
    public class CalculoJuroCompostoService : ICalculoJuroCompostoService
    {
        private readonly IMediator _mediator;
        private readonly ICalculadoraRepository _calculadoraRepository;        

        public CalculoJuroCompostoService(IMediator mediator, ICalculadoraRepository calculadoraRepository)
        {
            _mediator = mediator;
            _calculadoraRepository = calculadoraRepository;
        }

        public async Task<decimal> CalcularJuroComposto(decimal valorInicial, int meses)
        {
            var taxaJuros = await _calculadoraRepository.ObterTaxaJuros();

            var calculadoraJuroComposto = new CalculoJuroComposto(valorInicial, meses, taxaJuros);

            if (calculadoraJuroComposto.EhValido())            
                return calculadoraJuroComposto.Calcular();

            NotificarValidacoesErro(calculadoraJuroComposto.ValidationResult);
            return 0;
        }

        private void NotificarValidacoesErro(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                _mediator.Publish(new DomainNotification(error.PropertyName, error.ErrorMessage));
            }
        }
    }
}