using Newtonsoft.Json;

namespace ServiceViber
{
    public class UserDetails
    {
        [JsonProperty("user")]
        public UserViber User { get; set; }
    }
}
