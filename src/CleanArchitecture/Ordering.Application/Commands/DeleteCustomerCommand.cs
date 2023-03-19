using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Commands
{
    public class DeleteCustomerCommand : IRequest<String>
    {
        public Guid Id { get; private set; }

        public DeleteCustomerCommand(Guid Id)
        {
            this.Id = Id;
        }
    }
}
