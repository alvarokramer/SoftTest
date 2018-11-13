using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoftplanTeste.Domain.Common.Notifications;

namespace Calculadora.Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public class SobreController : Controller
    {
        [HttpGet]
        [Route("sobre/github")]
        public IActionResult Sobre()
        {
            return Ok(new
            {
                gitHubLink = "https://github.com/alvarokramer/SoftTest"
            });
        }
    }
}
