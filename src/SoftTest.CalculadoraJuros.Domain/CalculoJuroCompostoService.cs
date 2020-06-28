using System.Threading.Tasks;

namespace SoftTest.CalculadoraJuros.Domain
{
    public class CalculoJuroCompostoService : ICalculoJuroCompostoService
    {
        private readonly ICalculadoraRepository _calculadoraRepository;

        public CalculoJuroCompostoService(ICalculadoraRepository calculadoraRepository)
        {
            _calculadoraRepository = calculadoraRepository;
        }

        public async Task<decimal> CalcularJuroComposto(decimal valorInicial, int meses)
        {
            var taxaJuros = await _calculadoraRepository.ObterTaxaJuros();

            var calculadoraJuroComposto = new CalculoJuroComposto(valorInicial, meses, taxaJuros);

            if (calculadoraJuroComposto.IsValid())            
                return calculadoraJuroComposto.Calcular();

            return 0;
        }        
    }
}