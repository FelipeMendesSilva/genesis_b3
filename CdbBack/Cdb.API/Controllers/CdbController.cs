using Autofac.Integration.WebApi;
using Cdb.App.Interfaces;
using Cdb.App.Requests;
using System;
using System.Web.Http;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace Cdb.API.Controllers
{
    [AutofacControllerConfiguration]
    public class CdbController : ApiController
    {
        private readonly ICdbHandler _cdbService;
        public CdbController(ICdbHandler cdbService)
        {
            _cdbService = cdbService;
        }

        /// <summary>
        /// Calculates the CDB yield based on the investment amount and the selected period in months.
        /// </summary>
        /// <param name="request">An object containing the invested amount and duration in months.</param>
        /// <returns>The simulation result including gross and net earnings.</returns>
        /// <response code="200">Returns the CDB simulation data successfully.</response>
        /// <response code="400">Invalid request (missing or incorrect data).</response>
        /// <response code="500">Internal error during calculation or processing.</response>
        [HttpPost]
        [Route("api/cdb/yield")]
        public IHttpActionResult CdbYield([FromBody] CdbRequest request)
        {
            var result = _cdbService.YieldHandler(request);
            if (result.StatusCode != 200)
                return BadRequest(result.ErrorMessage);

            return Ok(result.Value);
        }
    }
}
