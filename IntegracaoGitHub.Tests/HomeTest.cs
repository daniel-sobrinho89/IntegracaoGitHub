using IntegracaoGitHub.Controllers;
using IntegracaoGitHub.Infrastructure.Repository.Interface;
using IntegracaoGitHub.Models;
using IntegracaoGitHub.Services;
using IntegracaoGitHub.Tests.Stubs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace IntegracaoGitHub.Tests
{
    public class HomeTest
    {
        [Fact]
        public async Task Post_SetFavorite_OKAsync()
        {
            var repositoryMock = new Mock<IHomeRepository>();
            repositoryMock.Setup(x => x.SetFavoriteAsync(It.IsAny<SetFavoriteRequest>())).Returns(Task.FromResult<int>(1));

            var serviceMock = new Mock<HomeService>(repositoryMock.Object);

            var controller = new HomeController(serviceMock.Object);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            var result = await controller.SetFavoriteAsync(It.IsAny<SetFavoriteRequest>());
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Post_SetFavorite_ErrorAsync()
        {
            var repositoryMock = new Mock<IHomeRepository>();
            repositoryMock.Setup(x => x.SetFavoriteAsync(It.IsAny<SetFavoriteRequest>())).Returns(Task.FromResult<int>(0));

            var serviceMock = new Mock<HomeService>(repositoryMock.Object);

            var controller = new HomeController(serviceMock.Object);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            var result = await controller.SetFavoriteAsync(It.IsAny<SetFavoriteRequest>());
            var objResult = (ObjectResult)result;
            
            Assert.Equal(HttpStatusCode.InternalServerError, (HttpStatusCode)objResult.StatusCode);
        }

        [Fact]
        public async Task Post_SetFavorite_RepositoryName_BadRequestAsync()
        {
            var repositoryMock = new Mock<IHomeRepository>();
            repositoryMock.Setup(x => x.SetFavoriteAsync(It.IsAny<SetFavoriteRequest>())).Returns(Task.FromResult<int>(0));

            var serviceMock = new Mock<HomeService>(repositoryMock.Object);

            var controller = new HomeController(serviceMock.Object);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ModelState.AddModelError("RepositoryName", "test");

            var result = await controller.SetFavoriteAsync(It.IsAny<SetFavoriteRequest>());
            var objResult = (ObjectResult)result;

            Assert.Equal(HttpStatusCode.BadRequest, (HttpStatusCode)objResult.StatusCode);
        }

        [Fact]
        public async Task Post_SetFavorite_RepositoryId_BadRequestAsync()
        {
            var repositoryMock = new Mock<IHomeRepository>();
            repositoryMock.Setup(x => x.SetFavoriteAsync(It.IsAny<SetFavoriteRequest>())).Returns(Task.FromResult<int>(0));

            var serviceMock = new Mock<HomeService>(repositoryMock.Object);

            var controller = new HomeController(serviceMock.Object);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ModelState.AddModelError("RepositoryId", "");

            var result = await controller.SetFavoriteAsync(It.IsAny<SetFavoriteRequest>());
            var objResult = (ObjectResult)result;

            Assert.Equal(HttpStatusCode.BadRequest, (HttpStatusCode)objResult.StatusCode);
        }

        [Fact]
        public async Task Get_GetFavorites_OKAsync()
        {
            var repositoryMock = new Mock<IHomeRepository>();
            repositoryMock.Setup(x => x.GetFavoritesAsync()).Returns(Task.FromResult<List<SetFavoriteRequest>>(HomeStub.SetFavoriteRequestList()));

            var serviceMock = new Mock<HomeService>(repositoryMock.Object);

            var controller = new HomeController(serviceMock.Object);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            var result = await controller.GetFavoritesAsync();
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
