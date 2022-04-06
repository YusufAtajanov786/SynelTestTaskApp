using SynelTestTaskApp.Data_Access.Data.Repository.IRepository;
using SynelTestTaskApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynelTestTaskApp.Data_Access.Data.Repository
{
    internal class EmployeRepository:Repository<Employe>, IEmployeRepository
    {
        public EmployeRepository( AppDbContext dbContext)
            : base(dbContext)
        {

        }

    }
}
