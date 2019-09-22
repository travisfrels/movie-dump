using Newtonsoft.Json;

namespace MovieDump.Models
{
    public class Config
    {
        [JsonProperty("libraries")]
        public Library[] Libraries { get; set; }
    }
}