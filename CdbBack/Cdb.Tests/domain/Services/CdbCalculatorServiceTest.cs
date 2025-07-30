using Cdb.App.Requests;
using Cdb.Domain.Services;

namespace Cdb.Tests.Domain.Services
{
    public class CdbCalculatorServiceTest
    {
        [Fact]
        public void Yield_ValidRequest_ReturnsMax2DecimalsAmount()
        {
            // Arrange            
            var cdbService = new CdbCalculatorService();

            // Act
            var result = cdbService.Yield(90.999999m, 2);

            // Assert            
            Assert.Equal(92.78m, result.GrossAmount);
            Assert.Equal(92.38m, result.NetAmount);
        }
    }
}
