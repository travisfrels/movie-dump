using System;
using System.Collections.Generic;
using System.IO;
using MovieDump.Business;
using MovieDump.DataAccess;
using MovieDump.Models;

namespace MovieDump
{
    class Program
    {
        static void Main(string[] args)
        {
            var configDataAccess = new ConfigDataAccess();
            var config = configDataAccess.GetConfig();

            var movieDataAccess = new MovieDataAccess();
            var movies = new List<Movie>();
            foreach (var lib in config.Libraries)
            {
                movies.AddRange(movieDataAccess.Read(lib));
            }

            using (var f = File.OpenWrite($"movie-dump-{DateTime.Now.ToString("yyyyMMdd-hhmmss")}.csv"))
            {
                using (var sw = new StreamWriter(f))
                {
                    var movieBusiness = new MovieBusiness();
                    sw.Write(movieBusiness.GetCsv(movies));
                }
            }
        }
    }
}
