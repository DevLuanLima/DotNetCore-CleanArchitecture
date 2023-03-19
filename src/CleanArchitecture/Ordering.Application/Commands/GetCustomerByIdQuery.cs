using MediatR;
using Ordering.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Commands
{
    public class GetCustomerByIdQuery : IRequest<Customer>
    {
        public Guid Id { get; set; }

        public GetCustomerByIdQuery(Guid Id)
        {
            this.Id = Id;
        }
    }
}
