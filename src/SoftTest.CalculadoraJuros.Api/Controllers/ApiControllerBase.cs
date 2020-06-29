using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoftTest.Shared.Notifications;
using System.Collections.Generic;
using System.Linq;

namespace SoftTest.CalculadoraJuros.Api.Controllers
{
    public abstract class ApiControllerBase : ControllerBase
    {
        private readonly DomainNotificationHandler _notifications;

        protected ApiControllerBase(INotificationHandler<DomainNotification> notifications)
        {
            _notifications = (DomainNotificationHandler)notifications;
        }

        protected bool OperacaoValida()
        {
            return !_notifications.TemNotificacoes();
        }

        protected IEnumerable<string> ObterMensagensErro()
        {
            return _notifications.ObterNotificacoes().Select(c => c.Value);
        }

        protected new IActionResult Response(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = ObterMensagensErro()
            });
        }
    }
}