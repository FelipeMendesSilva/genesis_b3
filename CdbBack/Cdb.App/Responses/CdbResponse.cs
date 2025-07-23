using Newtonsoft.Json;

namespace CdbApp.Responses
{
    public class CdbResponse
    {
        [JsonProperty("grossAmount")]
        public decimal GrossAmount { get; set; }
        [JsonProperty("netAmount")]
        public decimal NetAmount { get; set; }
    }
}
