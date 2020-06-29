using Xunit;
using Moq;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using SoftTest.Shared.Notifications;

namespace SoftTest.CalculadoraJuros.Domain.Tests.UnitTests
{
    public class CalculoJuroCompostoServiceTestes
    {
        public CalculoJuroCompostoService calculoJuroCompostoService { get; set; }
        public Mock<ICalculadoraRepository> mockCaculadoraRepository { get; set; }
        public Mock<IMediator> mockMediator { get; set; }

        public CalculoJuroCompostoServiceTestes()
        {
            mockCaculadoraRepository = new Mock<ICalculadoraRepository>();
            mockMediator = new Mock<IMediator>();
            calculoJuroCompostoService =
                new CalculoJuroCompostoService(mockMediator.Object, mockCaculadoraRepository.Object); ;
        }

        [Fact(DisplayName = "Calcular juro composto com sucesso")]
        [Trait("Calculadora", "Testes Calculo Juro Composto Service")]
        public void CalculoJuroCompostoService_CalcularJuroComposto_RetornarComSucesso() 
        {
            // Arrange
            decimal valorInicial = 100;
            int meses = 5;
            mockCaculadoraRepository.Setup(r => r.ObterTaxaJuros()).Returns(Task.FromResult(0.01));

            // Act            
            var result = calculoJuroCompostoService.CalcularJuroComposto(valorInicial, meses).Result;

            // Assert           
            mockCaculadoraRepository.Verify(m => m.ObterTaxaJuros(), Times.Once);
            Assert.Equal(105.10M, result);
        }

        [Fact(DisplayName = "Calcular juro composto com valor inicial inválido")]
        [Trait("Calculadora", "Testes Calculo Juro Composto Service")]
        public void CalculadoraCommandHandler_CalcularJuroComposto_ValorInicialInvalido() 
        {
            // Arrange
            decimal valorInicial = -1;
            int meses = 5;
            mockCaculadoraRepository.Setup(r => r.ObterTaxaJuros()).Returns(Task.FromResult(0.01));

            // Act            
            var result = calculoJuroCompostoService.CalcularJuroComposto(valorInicial, meses).Result;

            // Assert           
            mockCaculadoraRepository.Verify(m => m.ObterTaxaJuros(), Times.Once);
            mockMediator.Verify(m => m.Publish(It.IsAny<DomainNotification>(), It.IsAny<CancellationToken>()), Times.Once);
            Assert.Equal(0, result);
        }

        [Fact(DisplayName = "Calcular juro composto com número de meses inválido")]
        [Trait("Calculadora", "Testes Calculo Juro Composto Service")]
        public void CalculadoraCommandHandler_CalcularJuroComposto_NumeroMesesInvalido() 
        {
            // Arrange
            decimal valorInicial = 100;
            int meses = 13;
            mockCaculadoraRepository.Setup(r => r.ObterTaxaJuros()).Returns(Task.FromResult(0.01));
                
            // Act            
            var result = calculoJuroCompostoService.CalcularJuroComposto(valorInicial, meses).Result;

            // Assert           
            mockCaculadoraRepository.Verify(m => m.ObterTaxaJuros(), Times.Once);
            mockMediator.Verify(m => m.Publish(It.IsAny<DomainNotification>(), It.IsAny<CancellationToken>()), Times.Once);
            Assert.Equal(0, result);
        }
    }
}