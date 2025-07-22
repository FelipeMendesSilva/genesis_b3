using log4net;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace Cdb.API.Filters
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(GlobalExceptionFilter));
        public override void OnException(HttpActionExecutedContext context)
        {
            context.Response = context.Request.CreateErrorResponse(
            HttpStatusCode.InternalServerError,
            "Ocorreu um erro inesperado no servidor.");
            log.Error("Error during CDB calculation", context.Exception);
        }
    }
}