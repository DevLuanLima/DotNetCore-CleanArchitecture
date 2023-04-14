using Microsoft.AspNetCore.Hosting;
using Ordering.Application.Handlers.CommandHandlers;
using Ordering.Core.Repositories.Command.Base;
using Ordering.Core.Repositories.Query.Base;
using Ordering.Core.Repositories.Query;
using Ordering.Infrastructure.Repositories.Command.Base;
using Ordering.Infrastructure.Repositories.Command;
using Ordering.Infrastructure.Repositories.Query.Base;
using Ordering.Infrastructure.Repositories.Query;
using System.Reflection;
using MediatR;
using Ordering.Core.Repositories.Command;
using Ordering.Infrastructure.Context;

namespace Ordering.API.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection SolvingDependencies(this IServiceCollection services)
        {
            //services.AddScoped(provider => provider.GetService<OrderingContext>());

            services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(typeof(CreateCustomerHandler).Assembly); });
            services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
            services.AddTransient<ICustomerQueryRepository, CustomerQueryRepository>();
            services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
            services.AddTransient<ICustomerCommandRepository, CustomerCommandRepository>();

            return services;

        }
    }
}
