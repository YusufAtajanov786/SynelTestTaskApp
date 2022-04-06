using Microsoft.EntityFrameworkCore;
using SynelTestTaskApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynelTestTaskApp.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext( DbContextOptions<AppDbContext> dbContext )
            : base( dbContext )
        {

        }

        public DbSet<Employe> Employes { get; set; }
    }
}
