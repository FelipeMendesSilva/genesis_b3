using Cdb.Domain.DTO;
using Cdb.Domain.Helpers;
using Cdb.Domain.Interfaces;

namespace Cdb.Domain.Services
{
    public class CdbCalculatorService : ICdbCalculatorService
    {
        public CdbYeldDTO Yeld(double value, int months)
        {
            double cdi = 0.009;
            double tb = 1.08;

            double totalGross = value;
            for (int i = 0; i < months; i++)
            {
                totalGross = totalGross * (1 + (cdi * tb));
            }

            double tax = CdbTaxHelper.CdbTax(months);
            double yeld = totalGross - value;
            double taxedYeld = yeld * tax;
            double totalNet = totalGross - taxedYeld;

            return new CdbYeldDTO() { GrossAmount = totalGross, NetAmount = totalNet};
        }
    }
}
