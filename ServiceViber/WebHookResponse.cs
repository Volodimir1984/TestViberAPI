using Newtonsoft.Json;

namespace ServiceViber
{
    public class WebHookResponse
    {
        [JsonProperty("sender")]
        public UserViber User { get; set; }
    }
}
