using FluentValidation.Results;
using MediatR;
using SoftplanTeste.Domain.Common.Notifications;

namespace SoftPlanTest.Domain.Handlers
{
    public abstract class BaseCommandHandler
    {        
        private readonly IMediator _mediator;        

        protected BaseCommandHandler(IMediator mediator)
        {            
            _mediator = mediator;            
        }

        protected void NotificarValidacoesErro(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                _mediator.Publish(new DomainNotification(error.PropertyName, error.ErrorMessage));
            }
        }
    }
}
