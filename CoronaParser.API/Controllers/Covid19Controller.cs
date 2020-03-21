using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
// newtonsoft
using Newtonsoft.Json;

namespace CoronaParser.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Covid19Controller : ControllerBase
    {
        public Covid19Controller()
        {

        }

        [HttpGet("covidresults")]
        public async Task<ActionResult<CovidResult>> Get()
        {
            CovidResult result;

            try
            {
                using (var client = new HttpClient())
                {
                    string url = string.Format("https://covid19.mathdro.id/api");
                    var response = client.GetAsync(url).Result;
                    
                    string responseAsString = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<CovidResult>(responseAsString);
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

            return Ok(result);
        }
    }

    public class CovidResult
    {
        [JsonProperty("confirmed")]
        public ValueModel Confirmed { get; set; }
        [JsonProperty("recovered")]
        public ValueModel Recovered { get; set; }
        [JsonProperty("deaths")]
        public ValueModel Deaths { get; set; }
    }

    public class ValueModel
    {
        [JsonProperty("value")]
        public int Value { get; set; }
    }
}