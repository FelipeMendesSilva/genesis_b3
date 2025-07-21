using Cdb.App.Requests;
using Cdb.Domain.Result;

namespace Cdb.App.Interfaces
{
    public interface ICdbHandler
    {
        Result YieldHandler(CdbRequest cdbRequest);
    }
}
