﻿using Microsoft.AspNetCore.Http;
using SynelTestTaskApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynelTestTaskApp.Data_Access.Data.Repository.IRepository
{
    public interface IEmployeRepository : IRepository<Employe>
    {
        int ReadFromCSVFileAndInsert(IFormFile file);
    }
}
