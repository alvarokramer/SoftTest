using Microsoft.AspNetCore.Mvc;

namespace SoftTest.CalculadoraJuros.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class SobreController : ControllerBase
    {
        [HttpGet]
        [Route("sobre/showmethecode")]
        public IActionResult ShowMeTheCode()
        {
            return Ok(new
            {
                gitHubLink = "https://github.com/alvarokramer/SoftTest"
            });
        }
    }
}