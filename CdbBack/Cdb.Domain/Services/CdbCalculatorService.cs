using Cdb.Domain.DTO;
using Cdb.Domain.Helpers;
using Cdb.Domain.Interfaces;
using System;

namespace Cdb.Domain.Services
{
    public class CdbCalculatorService : ICdbCalculatorService
    {
        public CdbYeldDTO Yield(decimal value, int months)
        {
            decimal cdi = 0.009m;
            decimal tb = 1.08m;

            decimal totalGross = value;
            for (int i = 0; i < months; i++)
            {
                totalGross = totalGross * (1 + (cdi * tb));
            }

            decimal tax = CdbTaxHelper.CdbTax(months);
            decimal yeld = totalGross - value;
            decimal taxedYeld = yeld * tax;
            decimal totalNet = totalGross - taxedYeld;

            return new CdbYeldDTO() { GrossAmount = Math.Round(totalGross,2), NetAmount = Math.Round(totalNet,2)};
        }
    }
}
