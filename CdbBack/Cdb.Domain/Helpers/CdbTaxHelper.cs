namespace Cdb.Domain.Helpers
{
    public class CdbTaxHelper
    {
        public static double CdbTax(int months)
        {
            switch (months)
            {
                case int v when v <= 6:
                    return 0.225;
                case int v when v > 6 && v <=12 :
                    return 0.2;
                case int v when v > 12 && v <= 24:
                    return 0.175;
                case int v when v > 24:
                    return 0.15;
                default:
                    return 0.0; // Caso deseje um padrão
            }
        }
    }
}
