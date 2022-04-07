using Castle.Core.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using SynelTestTaskApp.Controllers;
using SynelTestTaskApp.Data_Access.Data.Repository.IRepository;
using SynelTestTaskApp.ViewModels;
using System;
using System.Collections.Generic;
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
        public void Index_Returns_ActionResult()
        {
            //Arrange
            HomeController homeController = new HomeController(ILoggerStub.Object, IEmployeRepository.Object);

            // Act
            var actual = homeController.Index();

            //Assert
            Assert.IsType<ViewResult>(actual);

            
        }

        [Fact]
        public void Index_Returns_ActionResultWithHomeIndexViewModel()
        {
            //Arrange
            HomeController homeController = new HomeController(ILoggerStub.Object, IEmployeRepository.Object);

            // Act
            var actual = homeController.Index().Model as HomeIndexViewModel;

            //Assert
            Assert.Equal(null, actual.File);
            Assert.Equal(null, actual.CountOfInsertedRecords);
        }
    }
}
