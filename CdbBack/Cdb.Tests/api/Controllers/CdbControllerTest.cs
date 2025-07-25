using Cdb.API.Controllers;
using Cdb.App.Requests;
using Cdb.Domain.Result;
using Cdb.Tests;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Cdb.Controllers.Tests
{
    public class CdbControllerTest : BaseTest
    {
        [Fact]
        public void CdbYeld_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            _cdbHandlerMock.Setup(h => h.YieldHandler(It.IsAny<CdbRequest>()))
                .Returns(Result.Success("payload", 200));
            var cdbController = new CdbController(_cdbHandlerMock.Object);
            var request = new CdbRequest() { Months = 1, InitialAmount = 100 };

            // Act
            var resp = cdbController.CdbYield(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(resp); 
            var result = Assert.IsType<Result>(okResult.Value);
            Assert.Equal("payload", result.Data);
        }

        [Fact]
        public void CdbYeld_InvalidRequest_ReturnsBadRequest()
        {
            // Arrange
            _cdbHandlerMock.Setup(h => h.YieldHandler(It.IsAny<CdbRequest>()))
                .Returns(Result.Failure("invalid request error", 400));
            var cdbController = new CdbController(_cdbHandlerMock.Object);
            var request = new CdbRequest() { Months = -1, InitialAmount = 100 };

            // Act
            var resp = cdbController.CdbYield(request);

            // Assert
            var badRequest = Assert.IsType<BadRequestObjectResult>(resp);
            var result = Assert.IsType<Result>(badRequest.Value);
            Assert.Equal("invalid request error", result.ErrorMessage);
        }
    }
}
