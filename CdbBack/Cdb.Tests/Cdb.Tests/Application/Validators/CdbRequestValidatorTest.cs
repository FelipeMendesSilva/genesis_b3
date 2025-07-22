using Cdb.App.Requests;
using CdbApp.Validators;
using Xunit;

namespace Cdb.Tests.Application.Validators
{
    public class CdbRequestValidatorTest : BaseTest
    {
        [Fact]
        public void Validate_ValidRequest_ReturnsIsValid()
        {
            // Arrange            
            var request = new CdbRequest() { Months = 1, Value = 90 };
            var validator = new CdbRequestValidator();

            // Act
            var result = validator.Validate(request);

            // Assert
            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }

        [Theory]
        [InlineData(0, 100)]
        [InlineData(1, -100)]
        [InlineData(-1, 100)]
        [InlineData(1, 0)]
        public void Validate_InvalidRequest_ReturnsIsNotValid(int months, decimal value)
        {
            // Arrange
            var request = new CdbRequest() { Months = months, Value = value };
            var validator = new CdbRequestValidator();

            // Act
            var result = validator.Validate(request);

            // Assert
            Assert.False(result.IsValid);
            Assert.NotEmpty(result.Errors);
        }
    }
}
