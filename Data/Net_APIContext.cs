using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Net_API.Model;

namespace Net_API.Data
{
    public class Net_APIContext : DbContext
    {
        public Net_APIContext (DbContextOptions<Net_APIContext> options)
            : base(options)
        {
        }

        public DbSet<Net_API.Model.Users> Users { get; set; } = default!;
        public DbSet<Net_API.Model.Donhang> Donhang { get; set; } = default!;
        public DbSet<Net_API.Model.Product> Product { get; set; } = default!;
    }
}
