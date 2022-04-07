using Castle.Core.Logging;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using SynelTestTaskApp.Controllers;
using SynelTestTaskApp.Data_Access.Data.Repository.IRepository;
using SynelTestTaskApp.Models;
using SynelTestTaskApp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SynelTestTaskApp.Test
{
    public class HomeControllerTest
    {
        private Mock<ILogger<HomeController>> ILoggerStub = new Mock<ILogger<HomeController>>();
        private Mock<IEmployeRepository> IEmployeRepository = new Mock<IEmployeRepository>();
       

        [Fact]
        public void Index_Returns_ViewResult()
        {
            //Arrange
            HomeController homeController = new HomeController(ILoggerStub.Object, IEmployeRepository.Object);

            // Act
            var actual = homeController.Index();

            //Assert
            Assert.IsType<ViewResult>(actual);

            
        }

        [Fact]
        public void Index_Returns_ViewResultWithHomeIndexViewModel()
        {
            //Arrange
            HomeController homeController = new HomeController(ILoggerStub.Object, IEmployeRepository.Object);

            // Act
            var actual = homeController.Index().Model as HomeIndexViewModel;

            //Assert
            Assert.Equal(null, actual.File);
            Assert.Equal(null, actual.CountOfInsertedRecords);
        }
        [Fact]
        public void GetAllEmployeRecords_Returns_EmployeesRecords()
        {

            //Arrange
            IEnumerable<Employee> employee = new Employee[] { 
                new Employee() {

                    Id = 1,
                    Payroll_Number = "Qa1dasd",
                    Forenames = "Qalandar",
                    Surname = "Surname"
                }
            };

           
            HomeController homeController = new HomeController(ILoggerStub.Object, IEmployeRepository.Object);
            IEmployeRepository.Setup(x => x.GetAll())
                .Returns(employee);

            // Act
            var actual = homeController.GetAllEmployeRecords() as JsonResult;

            //Assert
           
            
           
        }

        [Fact]
        public void Edit_Returns_ViewResultWithEmployeeData()
        {
            //Arrange
            var employee = new Employee()
            {

                Id = 1,
                Payroll_Number = "Qa1dasd",
                Forenames = "Qalandar",
                Surname = "Surname"
            };

            HomeController homeController = new HomeController(ILoggerStub.Object, IEmployeRepository.Object);
            IEmployeRepository.Setup(x => x.Get(It.IsAny<int>()))
                .Returns(employee);

            // Act
            var actual = homeController.Edit(1).Model as HomeEditViewModel;

            //Assert
           employee.Should().BeEquivalentTo(actual);
           
        }

        [Fact]
        public void Edit_Returns_ViewResultWithEditedEmployeeData()
        {
            //Arrange
            var employee = new Employee()
            {

                Id = 1,
                Payroll_Number = "Qa1dasd",
                Forenames = "Qalandar",
                Surname = "Surname"
            };
            var newEmployee = new HomeEditViewModel()
            {
                Id = 1,
                Payroll_Number = "Karim",
                Forenames = "Qalandar",
                Surname = "Surname"
            };

            HomeController homeController = new HomeController(ILoggerStub.Object, IEmployeRepository.Object);
            IEmployeRepository.Setup(x => x.Get(It.IsAny<int>()))
                .Returns(employee);

            // Act
            var result = homeController.Edit(newEmployee) as RedirectToActionResult;

            //Assert

            Assert.Equal("Index", result.ActionName);
        }




        [Fact]
        public void Index_Post_Returns_ParsedJson()
        {
            //Arrange
            HomeController homeController = new HomeController(ILoggerStub.Object, IEmployeRepository.Object);
            var fileMock = new Mock<IFormFile>();
            var content = "Personnel_Records.Payroll_Number,Personnel_Records.Forenames,Personnel_Records.Surname,Personnel_Records.Date_of_Birth,Personnel_Records.Telephone,Personnel_Records.Mobile,Personnel_Records.Address,Personnel_Records.Address_2,Personnel_Records.Postcode,Personnel_Records.EMail_Home,Personnel_Records.Start_Date\n"+
                            "COOP08,John ,William,26 / 01 / 1955,12345678,987654231,12 Foreman road, London, GU12 6JW,nomadic20 @hotmail.co.uk,18 / 04 / 2013";
            var fileName = "test.csv";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(content);
            writer.Flush();
            ms.Position = 0;
            fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
            fileMock.Setup(_ => _.FileName).Returns(fileName);
            fileMock.Setup(_ => _.Length).Returns(ms.Length);

            HomeIndexViewModel homeIndex = new HomeIndexViewModel()
            {
                File = fileMock.Object
            };

            // Act
            var actual = homeController.Index(homeIndex);

            //Assert
            Assert.IsType<ViewResult>(actual);
        }
    }
}
