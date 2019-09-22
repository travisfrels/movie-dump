using Newtonsoft.Json;

namespace MovieDump.Models
{
    public class Config
    {
        [JsonProperty("plexDbConnection")]
        public string PlexDbConnectionString { get; set; }
    }
}