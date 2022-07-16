using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersBaseFC.Domain.Entities;

namespace UsersBaseFC.Application.Interfaces
{
    public interface IEFContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        DbSet<User> Users { get; set; }
    }
}
