using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DTP.Models;

namespace DTP.Data
{
    public class DTPContext : DbContext
    {
        public DTPContext (DbContextOptions<DTPContext> options)
            : base(options)
        {
        }

        public DbSet<Sites> Sites { get; set; } = default!;
        public DbSet<DTPs> DTPs { get; set; } = default!;
    }
}
