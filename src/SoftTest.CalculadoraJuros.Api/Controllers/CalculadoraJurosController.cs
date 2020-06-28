using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SoftTest.CalculadoraJuros.Domain;

namespace SoftTest.CalculadoraJuros.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class CalculadoraJurosController : ControllerBase
    {
        private readonly ICalculoJuroCompostoService _calculoJuroCompostoService;

        public CalculadoraJurosController(ICalculoJuroCompostoService calculoJuroCompostoService)
        {
            _calculoJuroCompostoService = calculoJuroCompostoService;
        }

        [HttpGet]
        [Route("api/calcularjuros")]
        public async Task<IActionResult> CalcularJuroComposto(decimal valorInicial, int meses)
        {
            var result = await _calculoJuroCompostoService.CalcularJuroComposto(valorInicial, meses);

            return Ok(new { juroComposto = result.ToString("0.00") } );
        }
    }
}
