using MediatR;
using SoftplanTeste.Domain.Common.Commands;

namespace SoftPlanTest.Domain.Calculadora.Commands
{
    public class CalcularJuroCompostoCommand : Command, IRequest<decimal>
    {
        public decimal ValorInicial { get; private set; }
        public int Meses { get; private set; }

        public CalcularJuroCompostoCommand(decimal valorInicial, int meses)
        {
            ValorInicial = valorInicial;
            Meses = meses;
        }
    }
}
