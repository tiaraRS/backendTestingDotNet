using backend1.Controllers;
using backend1.Data.Entity;
using backend1.Data.Repository;
using backend1.Models;
using backend1.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.ControllersUT
{
    public class ChildControllerUT
    {
        //[Fact]
       /* public async Task Index_ReturnsAViewResult_WithAListOfBrainstormSessions()
        {
            var martina = new ChildModel()
            {
                ChildName = "Martina",
                BirthDate = new DateTime(2007, 3, 5)
            };
            martina.Id = 1;
            var listChild = new List<ChildModel>() { martina };
            var lChild2 = listChild as IEnumerable<ChildModel>;
            var en = new Task<IEnumerable<childModel>>(l=>l.Id);
            var enumerable = (Task<List<ChildModel>>)(lChild2);

            // Arrange
            var mockService = new Mock<IChildService>();
            mockService.Setup(service => service.GetChildrenAsync()).Returns(enumerable);
            var controller = new ChildrenController(mockService.Object);

            // Act
            var result = await controller.GetChildrenAsync();
            //var childrenCount = await result;

            // Assert
            // var viewResult = Assert.IsType<ActionResult>(result);
            // var model = Assert.IsAssignableFrom<IEnumerable<ChildModel>>(
            //    viewResult.ViewData.Model);
            //var a = result.Value;
            Assert.Equal(3, result.Value.Count());
        }*/
    }
}
