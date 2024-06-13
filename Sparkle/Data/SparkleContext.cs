using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SparkelStrands.Models;

namespace Sparkle.Data
{
    public class SparkleContext : DbContext
    {
        public SparkleContext (DbContextOptions<SparkleContext> options)
            : base(options)
        {
        }

        public DbSet<SparkelStrands.Models.Bracelete> Bracelete { get; set; } = default!;
    }
}
