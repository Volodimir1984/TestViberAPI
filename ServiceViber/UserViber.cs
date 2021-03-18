using Newtonsoft.Json;

namespace ServiceViber
{
    public class UserViber
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("language")]
        public string Language { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("device_type")]
        public string DeviceType{get; set;}
    }
}
