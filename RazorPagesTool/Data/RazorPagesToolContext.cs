using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesTool.Models;

namespace RazorPagesTool.Data
{
    public class RazorPagesToolContext : DbContext
    {
        public RazorPagesToolContext (DbContextOptions<RazorPagesToolContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Basket>()
                .HasMany(b => b.Tools);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<RazorPagesTool.Models.Tool> Tools { get; set; } = default!;
        public DbSet<RazorPagesTool.Models.Basket> Baskets { get; set; } = default!;

    }
}
