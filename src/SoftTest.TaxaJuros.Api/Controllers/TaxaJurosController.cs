using Microsoft.AspNetCore.Mvc;

namespace SoftTest.TaxaJuros.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class TaxaJurosController : ControllerBase
    {
        private readonly double _taxaJuros = 0.01;

        [HttpGet]
        [Route("api/taxaJuros")]
        public double Get() 
        {
            return _taxaJuros;
        }
    }
}