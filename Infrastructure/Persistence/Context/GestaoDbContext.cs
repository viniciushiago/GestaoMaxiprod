using Domain.Entities;
using GestaoMaxiprod.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Context
{
    public class GestaoDbContext : DbContext
    {
        public GestaoDbContext(DbContextOptions<GestaoDbContext> options) : base(options){}

        public DbSet<Person> Persons { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GestaoDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
