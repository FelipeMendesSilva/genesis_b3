using Cdb.Domain.DTO;

namespace Cdb.Domain.Interfaces
{
    public interface ICdbCalculatorService
    {
        CdbYeldDTO Yeld(decimal value, int months);
    }
}
