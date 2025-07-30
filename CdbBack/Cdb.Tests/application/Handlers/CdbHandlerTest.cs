using Cdb.App.Handler;
using Cdb.App.Requests;
using Cdb.Domain.DTO;
using CdbApp.Responses;
using Moq;

namespace Cdb.Tests.Application.Handlers
{
    public class CdbHandlerTest : BaseTest
    {
        [Fact]
        public void YieldHandler_ValidRequest_ReturnsSuccessResult()
        {
            // Arrange
            var yieldResult = new CdbYieldDto() { GrossAmount = 110, NetAmount = 100 };
            _cdbCalculatorService.Setup(h => h.Yield(It.IsAny<decimal>(), It.IsAny<int>()))
                .Returns(yieldResult);
            var cdbHandler = new CdbHandler(_cdbCalculatorService.Object);
            var request = new CdbRequest() { Months = 2, InitialAmount = 90 };

            // Act
            var result = cdbHandler.YieldHandler(request);

            // Assert
            Assert.Equal(yieldResult.GrossAmount, (result.Data as CdbResponse)?.GrossAmount);
            Assert.Equal(yieldResult.NetAmount, (result.Data as CdbResponse)?.NetAmount);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void YieldHandler_InvalidRequest_ReturnsFailureResult()
        {
            // Arrange
            var yieldResult = new CdbYieldDto() { GrossAmount = 110, NetAmount = 100 };
            _cdbCalculatorService.Setup(h => h.Yield(It.IsAny<decimal>(), It.IsAny<int>()))
                .Returns(yieldResult);
            var cdbHandler = new CdbHandler(_cdbCalculatorService.Object);
            var request = new CdbRequest() { Months = -1, InitialAmount = 90 };

            // Act
            var result = cdbHandler.YieldHandler(request);

            // Assert
            Assert.True(result.ErrorMessage != null);
            Assert.Equal(400, result.StatusCode);
        }
    }
}
