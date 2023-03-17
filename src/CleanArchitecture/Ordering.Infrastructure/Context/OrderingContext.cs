using Microsoft.EntityFrameworkCore;
using Ordering.Core.Entities;
using Ordering.Infrastructure.EntitiesConfiguration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Context
{
    public class OrderingContext : DbContext
    {
        public OrderingContext(DbContextOptions<OrderingContext> options) : base(options)
        {

        }

        public  DbSet<Customer> Customers {get; set;}


        //Configuration Entities
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CustomerConfiguration());

        }
    }
}
