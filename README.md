# CoronaParser
Parsing the covid19 api

```C#
using (var client = new HttpClient())
{
  string url = string.Format("https://covid19.mathdro.id/api");
  var response = client.GetAsync(url).Result;

  string responseAsString = await response.Content.ReadAsStringAsync();
  result = JsonConvert.DeserializeObject<CovidResult>(responseAsString);
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
```
