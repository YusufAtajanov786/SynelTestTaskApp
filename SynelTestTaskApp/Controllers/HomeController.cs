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

        public IActionResult Index()
        {
            return View();
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

        [HttpGet]
        public IActionResult GetAllEmployeRecords()
        {
            return Json(new { data = _employeRepository.GetAll() });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
