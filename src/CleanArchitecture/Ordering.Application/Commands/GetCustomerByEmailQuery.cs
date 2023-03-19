using MediatR;
using Ordering.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Commands
{
    public class GetCustomerByEmailQuery : IRequest<Customer>
    {
        public string Email { get; set; }   

        public GetCustomerByEmailQuery(string email)
        {
            Email = email;
        }
    }
}
