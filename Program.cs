using System;
using System.IO;
using CsvHelper;
using MovieDump.DataAccess;

namespace MovieDump
{
    class Program
    {
        static void Main(string[] args)
        {
            var configDataAccess = new ConfigDataAccess();
            var config = configDataAccess.GetConfig();
            var plex = new PlexDbDataAccess(config.PlexDbConnectionString);

            using (var csv = new CsvWriter(new StreamWriter(File.OpenWrite($"movie-dump-{DateTime.Now.ToString("yyyyMMdd-hhmmss")}.csv"))))
            {
                csv.WriteRecords(plex.GetMovies());
            }
        }
    }
}
