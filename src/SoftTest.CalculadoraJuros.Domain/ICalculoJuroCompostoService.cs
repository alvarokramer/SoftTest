using System.Threading.Tasks;

namespace SoftTest.CalculadoraJuros.Domain
{
    public interface ICalculoJuroCompostoService
    {
        Task<decimal> CalcularJuroComposto(decimal valorInicial, int meses);
    }
}