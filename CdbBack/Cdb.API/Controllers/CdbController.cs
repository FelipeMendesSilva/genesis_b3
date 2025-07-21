using Autofac.Integration.WebApi;
using Cdb.App.Interfaces;
using Cdb.App.Requests;
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
                
        [HttpPost]
        public IHttpActionResult Get([FromBody] CdbRequest request)
        {
            var result = _cdbService.Handler(request);
            if (result.StatusCode != 200)
                return BadRequest(result.ErrorMessage);

            return Ok(result.Value);
        }
    }
}
