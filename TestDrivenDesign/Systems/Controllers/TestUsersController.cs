using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestDrivenDesign.MockData;
using WebApiTDD.Controllers;
using WebApiTDD.Models;
using WebApiTDD.Services;
using Xunit;
//using TestDrivenDesign.MockData;

namespace TestDrivenDesign.Systems.Controllers
{
    public class TestUsersController
    {
        [Fact]
        public async Task Get_OnSuccess_ReturnsStatusCode200()
        {
            /*
                // Pasos
            1) Arrange
            2) Act
            3) Assert
            */

            // Arrange
            var mockUsersService = new Mock<IUsersService>();
            mockUsersService
               .Setup(service => service.GetAllUsers())
               .ReturnsAsync(UsersMock.GetTestUsers())
           ;
            var sut = new UsersController(mockUsersService.Object);

            // Act
            var result = (OkObjectResult) await sut.Get();

            // Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Get_OnSuccess_InvokesUserServiceExactlyOnce()
        {
            // Arrange
            var mockUsersService = new Mock<IUsersService>();
            mockUsersService
                .Setup(service => service.GetAllUsers())
                .ReturnsAsync(UsersMock.GetTestUsers())
            ;
            var sut = new UsersController(mockUsersService.Object);

            // Act
            var result = (OkObjectResult) await sut.Get();

            // Assert
            mockUsersService.Verify(
                service => service.GetAllUsers(),
                Times.Once()
            );
        }

        [Fact]
        public async Task Get_OnSuccess_ReturnsListOfUsers()
        {
            // Arrange
            var mockUsersService = new Mock<IUsersService>();
            mockUsersService
                .Setup(service => service.GetAllUsers())
                .ReturnsAsync(UsersMock.GetTestUsers())
            ;
            var sut = new UsersController(mockUsersService.Object);

            // Act
            var result = (OkObjectResult)await sut.Get();

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<List<User>>();
        }

        [Fact]
        public async Task Get_OnNoUsersFound_Returns404()
        {
            // Arrange
            var mockUsersService = new Mock<IUsersService>();
            mockUsersService
                .Setup(service => service.GetAllUsers())
                .ReturnsAsync(new List<User>())
            ;
            var sut = new UsersController(mockUsersService.Object);

            // Act
            var result = await sut.Get();

            // Assert
            result.Should().BeOfType<NotFoundResult>();
        }
    }
}