using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SynelTestTaskApp.Data_Access.Data.Repository.IRepository;
using SynelTestTaskApp.Models;
using SynelTestTaskApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SynelTestTaskApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeRepository _employeRepository;

        public HomeController(ILogger<HomeController> logger, IEmployeRepository employeRepository)
        {
            _logger = logger;
            this._employeRepository = employeRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAllEmployeRecords()
        {
            return Json(new { data = _employeRepository.GetAll() });
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee employe = _employeRepository.Get(id);
            HomeEditViewModel homeEditViewModel = new HomeEditViewModel()
            {
                Id = id,
                Payroll_Number = employe.Payroll_Number,
                Forenames = employe.Forenames,
                Surname = employe.Surname,
                Date_of_Birth = employe.Date_of_Birth,
                Telephone = employe.Telephone,
                Mobile = employe.Mobile,
                Address = employe.Address,
                Address_2 = employe.Address_2,
                Postcode = employe.Postcode,
                EMail_Home = employe.EMail_Home,
                Start_Date = employe.Start_Date
            };
            return View(homeEditViewModel);
        }
        [HttpPost]
        public IActionResult Edit(HomeEditViewModel homeEditViewModel)
        {
            if(!ModelState.IsValid)
                return View(homeEditViewModel);
            Employee employee = _employeRepository.Get(homeEditViewModel.Id);

            employee.Payroll_Number = homeEditViewModel.Payroll_Number;
            employee.Forenames = homeEditViewModel.Forenames;
            employee.Surname = homeEditViewModel.Surname;
            employee.Date_of_Birth = homeEditViewModel.Date_of_Birth;
            employee.Telephone = homeEditViewModel.Telephone;
            employee.Mobile = homeEditViewModel.Mobile;
            employee.Address = homeEditViewModel.Address;
            employee.Address_2 = homeEditViewModel.Address_2;
            employee.Postcode = homeEditViewModel.Postcode;
            employee.EMail_Home = homeEditViewModel.EMail_Home;
            employee.Start_Date = homeEditViewModel.Start_Date;

            _employeRepository.Update(employee);
            _employeRepository.Save();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Index(HomeIndexViewModel homeIndexViewModel)
        {
            HomeIndexViewModel homeIndex = new HomeIndexViewModel();
            if( homeIndexViewModel.File != null)
            {
                homeIndex.CountOfInsertedRecords = _employeRepository.ReadFromCSVFileAndInsert(homeIndexViewModel.File);
                _employeRepository.Save();
            } 
            return View(homeIndex);
        }

        
      

        [HttpDelete]
        public IActionResult Delete(int id)
        { 
            var result = _employeRepository.Remove(id);
            if(result == null)
            {
                return Json(new { success = false, message = "Failed" });
            }
            _employeRepository.Save();
            return Json(new { success = true, message = "Success" });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
