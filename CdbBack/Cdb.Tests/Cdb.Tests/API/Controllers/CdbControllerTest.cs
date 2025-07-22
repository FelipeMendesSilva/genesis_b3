using Cdb.API.Controllers;
using Cdb.API.Filters;
using Cdb.App.Requests;
using Cdb.Domain.Result;
using Cdb.Tests;
using Moq;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Xunit;

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
            var request = new CdbRequest() { Months = 1, Value = 100 };

            // Act
            var result = cdbController.CdbYield(request);

            // Assert
            var okResult = Assert.IsType<OkNegotiatedContentResult<object>>(result);
            Assert.Equal("payload", okResult.Content);
        }

        [Fact]
        public void CdbYeld_InvalidRequest_ReturnsBadRequest()
        {
            // Arrange
            _cdbHandlerMock.Setup(h => h.YieldHandler(It.IsAny<CdbRequest>()))
                .Returns(Result.Failure("invalid request error", 400));
            var cdbController = new CdbController(_cdbHandlerMock.Object);
            var request = new CdbRequest() { Months = -1, Value = 100 };

            // Act
            var result = cdbController.CdbYield(request);

            // Assert
            var badRequest = Assert.IsType<BadRequestErrorMessageResult>(result);
            Assert.Equal("invalid request error", badRequest.Message);
        }
    }
}
