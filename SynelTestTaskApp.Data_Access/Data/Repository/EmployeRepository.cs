using Microsoft.AspNetCore.Http;
using SynelTestTaskApp.Data_Access.Data.Repository.IRepository;
using SynelTestTaskApp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynelTestTaskApp.Data_Access.Data.Repository
{
    public class EmployeRepository:Repository<Employee>, IEmployeRepository
    {
        public EmployeRepository( AppDbContext dbContext)
            : base(dbContext)
        {

        }

        public int ReadFromCSVFileAndInsert(IFormFile file)
        {
           

            var records = new StringBuilder();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    records.AppendLine(reader.ReadLine());
            }

            string[] resultLines = records.ToString().Trim().Split(new char[] { '\n' });

            List<Employee> employes = resultLines.Skip(1).Select(x => Parse(x)).ToList();

            InsertEmployeeRecordsTotheDb(employes);

            return employes.Count;
        }

        private void InsertEmployeeRecordsTotheDb(List<Employee> employes)
        {
            foreach( var employe in employes)
            {
                _dbSet.Add(employe);
            }
        }

        public Employee Parse(string line)
        {
            string[] values = line.Split(',');
            Employee employe = new Employee();
            employe.Payroll_Number = values[0];
            employe.Forenames = values[1];
            employe.Surname = values[2];
            employe.Date_of_Birth = DateTime.ParseExact(values[3], "d/M/yyyy", CultureInfo.InvariantCulture);
            employe.Telephone = values[4];
            employe.Mobile = values[5];
            employe.Address = values[6];
            employe.Address_2 = values[7];
            employe.Postcode = values[8];
            employe.EMail_Home = values[9];
            employe.Start_Date = DateTime.ParseExact(values[10].TrimStart().TrimEnd(), "d/M/yyyy", CultureInfo.InvariantCulture);
            return employe;
        }

        public Employee Update(Employee employee)
        {
            var newEmployee = _dbSet.Attach(employee);
            newEmployee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return employee;
        }
    }
}
