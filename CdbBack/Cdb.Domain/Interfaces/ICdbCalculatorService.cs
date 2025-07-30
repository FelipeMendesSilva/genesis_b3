using Cdb.Domain.DTO;

namespace Cdb.Domain.Interfaces
{
    public interface ICdbCalculatorService
    {
        CdbYieldDto Yield(decimal initialAmount, int months);
    }
}
