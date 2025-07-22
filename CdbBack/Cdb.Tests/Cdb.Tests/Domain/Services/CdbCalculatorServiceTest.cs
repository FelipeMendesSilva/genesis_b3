using Cdb.App.Requests;
using Cdb.Domain.Services;
using Xunit;

namespace Cdb.Tests.Domain.Services
{
    public class CdbCalculatorServiceTest
    {
        [Fact]
        public void Yield_ValidRequest_ReturnsMax2DecimalsAmount()
        {
            // Arrange            
            var request = new CdbRequest() { Months = 1, Value = 90.999m };
            var cdbService = new CdbCalculatorService();

            // Act
            var result = cdbService.Yield(90.999999m, 1);

            // Assert            
            Assert.Equal(91.88m, result.GrossAmount);
            Assert.Equal(91.69m, result.NetAmount);
        }
    }
}
