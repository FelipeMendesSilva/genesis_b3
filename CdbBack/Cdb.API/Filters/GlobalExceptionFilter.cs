using Cdb.Domain.Result;
using Microsoft.AspNetCore.Diagnostics;

namespace Cdb.API.Filters
{    
    public sealed class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            _logger.LogError(exception, "Erro durante o cálculo de CDB");

            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            var result = Result.Failure("Ocorreu um erro inesperado no servidor.", StatusCodes.Status500InternalServerError);            
            await httpContext.Response.WriteAsJsonAsync(result, cancellationToken);

            return true;
        }
    }
}
