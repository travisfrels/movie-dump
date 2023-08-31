using System.IO;
using MovieDump.Models;
using Newtonsoft.Json;

namespace MovieDump.DataAccess
{
    public class ConfigDataAccess
    {
        private static Config _config;

        public Config GetConfig()
        {
            if (_config == null)
            {
                using (var sr = new StreamReader(File.OpenRead("config.json")))
                {
                    _config = JsonConvert.DeserializeObject<Config>(sr.ReadToEnd());
                }
            }
            return _config;
        }
    }
}