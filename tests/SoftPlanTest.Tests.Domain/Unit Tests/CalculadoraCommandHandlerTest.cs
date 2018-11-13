using MediatR;
using Moq;
using SoftPlanTest.Domain.Calculadora.Commands;
using SoftPlanTest.Domain.Calculadora.Handlers;
using SoftplanTeste.Domain.Common.Notifications;
using System.Threading;
using Xunit;

namespace SoftPlanTest.Tests.Domain.Unit_Tests
{
    public class CalculadoraCommandHandlerTest
    {
        public CalcularJuroCompostoCommand calculoJuroCompostCommand { get; set; }
        public CalculadoraCommandHandler commandHandler { get; set; }
        public Mock<IMediator> mockMediator { get; set; }

        public CalculadoraCommandHandlerTest()
        {
            mockMediator = new Mock<IMediator>();
            commandHandler = new CalculadoraCommandHandler(mockMediator.Object);            
        }

        [Fact(DisplayName = "Calcular juro composto com sucesso")]
        [Trait("Calculadora", "Testes Calculadora Command Handler")]
        public void CalculadoraCommandHandler_CalcularJuroComposto_RetornarComSucesso()
        {
            // Arrange
            calculoJuroCompostCommand = new CalcularJuroCompostoCommand(100, 5);            

            // Act
            var result  = commandHandler.Handle(calculoJuroCompostCommand, CancellationToken.None).Result;

            // Assert
            mockMediator.Verify(m => m.Publish(It.IsAny<DomainNotification>(), It.IsAny<CancellationToken>()), Times.Never);
            Assert.Equal("105.10", result.ToString("0.00"));
        }

        [Fact(DisplayName = "Calcular juro composto com valor inicial inválido")]
        [Trait("Calculadora", "Testes Calculadora Command Handler")]
        public void CalculadoraCommandHandler_CalcularJuroComposto_ValorInicialInvalido()
        {
            // Arrange
            calculoJuroCompostCommand = new CalcularJuroCompostoCommand(-1, 5);            

            // Act
            var result = commandHandler.Handle(calculoJuroCompostCommand, default(CancellationToken)).Result;           

            // Assert
            mockMediator.Verify(m => m.Publish(It.IsAny<DomainNotification>(), It.IsAny<CancellationToken>()), Times.Once);
            Assert.Equal(0, result);
        }

        [Fact(DisplayName = "Calcular juro composto com número de meses inválido")]
        [Trait("Calculadora", "Testes Calculadora Command Handler")]
        public void CalculadoraCommandHandler_CalcularJuroComposto_NumeroMesesInvalido()
        {
            // Arrange
            calculoJuroCompostCommand = new CalcularJuroCompostoCommand(100, 13);            

            // Act
            var result = commandHandler.Handle(calculoJuroCompostCommand, default(CancellationToken)).Result;

            // Assert
            mockMediator.Verify(m => m.Publish(It.IsAny<DomainNotification>(), It.IsAny<CancellationToken>()), Times.Once);
            Assert.Equal(0, result);
        }
    }
}
