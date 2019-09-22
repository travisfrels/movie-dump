using System;
using System.Collections.Generic;
using System.IO;
using MovieDump.Models;

namespace MovieDump.DataAccess
{
    public class MovieDataAccess
    {
        public Movie[] Read(Library library)
        {
            if (library is null) { throw new ArgumentNullException(nameof(library)); }

            var response = new List<Movie>();
            foreach (var fileName in Directory.GetFiles(library.Path))
            {
                using (var f = File.OpenRead(fileName))
                {
                    response.Add(new Movie { Title = f.Name.Substring(library.Path.Length + 1), Size = Convert.ToInt32(f.Length >> 20), Format = library.Format });
                }
            }
            return response.ToArray();
        }
    }
}