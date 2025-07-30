using Cdb.App.Requests;
using Cdb.App.Validators;

namespace Cdb.Tests.Application.Validators
{
    public class CdbRequestValidatorTest : BaseTest
    {
        [Fact]
        public void Validate_ValidRequest_ReturnsIsValid()
        {
            // Arrange            
            var request = new CdbRequest() { Months = 2, InitialAmount = 90 };
            var validator = new CdbRequestValidator();

            // Act
            var result = validator.Validate(request);

            // Assert
            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }

        [Theory]
        [InlineData(0, 100)]
        [InlineData(2, -100)]
        [InlineData(-1, 100)]
        [InlineData(2, 0)]
        public void Validate_InvalidRequest_ReturnsIsNotValid(int months, decimal value)
        {
            // Arrange
            var request = new CdbRequest() { Months = months, InitialAmount = value };
            var validator = new CdbRequestValidator();

            // Act
            var result = validator.Validate(request);

            // Assert
            Assert.False(result.IsValid);
            Assert.NotEmpty(result.Errors);
        }
    }
}
