using Cdb.App.Interfaces;
using Cdb.App.Requests;
using Cdb.Domain.Interfaces;
using Cdb.Domain.Result;
using CdbApp.Responses;
using CdbApp.Validators;

namespace Cdb.App.Handler
{
    public class CdbHandler: ICdbHandler
    {
        private readonly ICdbCalculatorService _cdbCalculatorService;
        public CdbHandler(ICdbCalculatorService cdbCalculatorService)
        {
            _cdbCalculatorService = cdbCalculatorService;
        }
        public Result Handler(CdbRequest cdbRequest)
        {
            var validator = new CdbRequestValidator();
            var resultado = validator.Validate(cdbRequest);
            if (!resultado.IsValid)
            {
                var errors = "";
                foreach (var erro in resultado.Errors)
                {
                    errors += erro.ErrorMessage + "/ ";
                }
                return Result.Failure(errors);
            }

            var cdbYeldDTO = _cdbCalculatorService.Yeld(cdbRequest.Value, cdbRequest.Months);
            var cdbResponse = new CdbResponse() { GrossAmount = cdbYeldDTO.GrossAmount, NetAmount = cdbYeldDTO.NetAmount };
            return Result.Success(cdbResponse);
        }
    }
}
