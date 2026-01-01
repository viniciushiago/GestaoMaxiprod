using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoMaxiprod.Infrastructure.Persistence.Context
{
    public class GestaoDbContextFactory : IDesignTimeDbContextFactory<GestaoDbContext>
    {
        public GestaoDbContext CreateDbContext(string [] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<GestaoDbContext>();

            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=GestaoMaxiprodDb;Trusted_Connection=True;TrustServerCertificate=True");

            return new GestaoDbContext(optionsBuilder.Options);
        }
    }
}
