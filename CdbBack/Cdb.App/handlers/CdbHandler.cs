using Cdb.App.Interfaces;
using Cdb.App.Requests;
using Cdb.Domain.Interfaces;
using Cdb.Domain.Result;
using Cdb.App.Responses;
using Cdb.App.Validators;
using System.Text;

namespace Cdb.App.Handlers
{
    public class CdbHandler: ICdbHandler
    {
        private readonly ICdbCalculatorService _cdbCalculatorService;

        public CdbHandler(ICdbCalculatorService cdbCalculatorService)
        {
            _cdbCalculatorService = cdbCalculatorService;
        }

        public Result YieldHandler(CdbRequest cdbRequest)
        {
            var validator = new CdbRequestValidator();
            var resultado = validator.Validate(cdbRequest);
            if (!resultado.IsValid)
            {
                StringBuilder errors = new StringBuilder();
                foreach (var erro in resultado.Errors)
                {
                    errors.Append(erro.ErrorMessage + " ");
                }
                
                return Result.Failure(errors.ToString());
            }

            var cdbYeldDTO = _cdbCalculatorService.Yield(cdbRequest.InitialAmount, cdbRequest.Months);
            var cdbResponse = new CdbResponse() { GrossAmount = cdbYeldDTO.GrossAmount, NetAmount = cdbYeldDTO.NetAmount };
            return Result.Success(cdbResponse);
        }
    }
}
