using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApiTDD.Controllers;
using Xunit;

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
            var sut = new UsersController();

            // Act
            var result = (OkObjectResult) sut.Get();

            // Assert
            result.StatusCode.Should().Be(200);
        }
    }
}