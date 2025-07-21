using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace Cdb.API.Filters
{
    public class GlobalErrorFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            context.Response = context.Request.CreateErrorResponse(
            HttpStatusCode.InternalServerError,
            "Ocorreu um erro inesperado no servidor.");
        }
    }
}