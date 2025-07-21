using Cdb.Domain.DTO;

namespace Cdb.Domain.Interfaces
{
    public interface ICdbCalculatorService
    {
        CdbYeldDTO Yield(decimal value, int months);
    }
}
