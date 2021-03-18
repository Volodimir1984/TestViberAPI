using Newtonsoft.Json;

namespace ServiceViber
{
    public class WeebHookResult
    {
        [JsonProperty("status")]
        public int Status { get; set; }
    }
}
