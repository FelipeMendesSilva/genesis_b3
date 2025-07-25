using Cdb.Domain.DTO;

namespace Cdb.Domain.Interfaces
{
    public interface ICdbCalculatorService
    {
        CdbYieldDTO Yield(decimal initialAmount, int months);
    }
}
