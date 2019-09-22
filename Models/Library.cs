using Newtonsoft.Json;

namespace MovieDump.Models
{
    public class Library
    {
        [JsonProperty("path")]
        public string Path { get; set; }
        
        [JsonProperty("format")]
        public string Format { get; set; }
    }
}