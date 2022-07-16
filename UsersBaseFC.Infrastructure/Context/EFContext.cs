using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersBaseFC.Application.Interfaces;
using UsersBaseFC.Domain.Entities;

namespace UsersBaseFC.Infrastructure.Context
{
    public class EFContext : DbContext, IEFContext
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder) 
        {
            modelbuilder.ApplyConfigurationsFromAssembly(typeof(EFContext).Assembly);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) 
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
