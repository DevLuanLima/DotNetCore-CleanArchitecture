using Ordering.Core.Entities;
using Ordering.Core.Repositories.Query.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Core.Repositories.Query
{
    public interface ICustomerQueryRepository : IQueryRepository<Customer>
    {
        //Operation which is not generic
        Task<IReadOnlyList<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(Guid id);
        Task<Customer> GetCustomerByEmail(string email);
    }
}
