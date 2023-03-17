using Microsoft.Extensions.Configuration;
using Ordering.Core.Repositories.Query.Base;
using Ordering.Infrastructure.Context;


namespace Ordering.Infrastructure.Repositories.Query.Base
{
    public class QueryRepository<T> : DbConnector, IQueryRepository<T> where T : class
    {
        public QueryRepository(IConfiguration configuration)
            : base(configuration)
        {

        }
    }
}
