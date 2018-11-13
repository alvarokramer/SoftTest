using MediatR;
using System;

namespace SoftplanTeste.Domain.Common.Commands
{
    public abstract class Command : IRequest
    {
        public DateTime Timestamp { get; private set; }

        public Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}
