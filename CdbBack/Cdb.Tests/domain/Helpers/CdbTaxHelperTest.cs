using Cdb.Domain.Helpers;

namespace Cdb.Tests.Domain.Helpers
{
    public class CdbTaxHelperTest
    {
        [Fact]
        public void CdbTax_LessThan6Months_Returns22_5()
        {   
            // Act
            var result = CdbTaxHelper.CdbTax(1);

            // Assert
            Assert.Equal(0.225m,result);
        }

        [Fact]
        public void CdbTax_Between6And12Months_Returns20()
        {
            // Act
            var result = CdbTaxHelper.CdbTax(8);

            // Assert
            Assert.Equal(0.2m, result);
        }

        [Fact]
        public void CdbTax_Between12And24Months_Returns17_5()
        {
            // Act
            var result = CdbTaxHelper.CdbTax(16);

            // Assert
            Assert.Equal(0.175m, result);
        }

        [Fact]
        public void CdbTax_MoreThan24Months_Returns15()
        {
            // Act
            var result = CdbTaxHelper.CdbTax(26);

            // Assert
            Assert.Equal(0.15m, result);
        }
    }
}
