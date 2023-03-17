using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Core.Repositories.Command.Base
{
    public interface ICommandRepository<T> where T : class
    {
        Task<T> AddAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(T item);
    }
}
