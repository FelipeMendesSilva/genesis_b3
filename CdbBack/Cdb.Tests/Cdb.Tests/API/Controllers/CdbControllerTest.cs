using Xunit;

namespace Cdb.Controllers.Tests
{
    public class CdbControllerTest
    {
        [Fact]
        public void Add_TwoNumbers_ReturnsSum()
        {
            // Arrange
            int a = 5, b = 10;

            // Act
            int result = a+b;

            // Assert
            Assert.Equal(15, result);
        }
    }
}
