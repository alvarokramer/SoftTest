using System.Threading.Tasks;

namespace SoftTest.CalculadoraJuros.Domain
{
    public interface ICalculadoraRepository 
    {
        Task<double> ObterTaxaJuros();
    }
}