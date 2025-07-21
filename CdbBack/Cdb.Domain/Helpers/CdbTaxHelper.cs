namespace Cdb.Domain.Helpers
{
    public class CdbTaxHelper
    {
        public static decimal CdbTax(int months)
        {
            switch (months)
            {
                case int v when v <= 6:
                    return 0.225m;
                case int v when v > 6 && v <=12 :
                    return 0.2m;
                case int v when v > 12 && v <= 24:
                    return 0.175m;
                case int v when v > 24:
                    return 0.15m;
                default:
                    return 0m;
            }
        }
    }
}
