using System.Collections.Generic;
using System.Text;
using System.Linq;
using MovieDump.Models;

namespace MovieDump.Business
{
    public class MovieBusiness
    {
        public string GetCsvHeader()
        {
            return "Title,Size,Format";
        }

        public string GetCsvRow(Movie movie)
        {
            if (movie is null) { throw new System.ArgumentNullException(nameof(movie)); }
            return $"{movie.Title},{movie.Size},{movie.Format}";
        }

        public string GetCsv(IEnumerable<Movie> movies)
        {
            if (movies is null) { throw new System.ArgumentNullException(nameof(movies)); }

            var csvBuilder = new StringBuilder();
            csvBuilder.AppendLine(GetCsvHeader());
            foreach (var m in movies.OrderBy(x => x.Title))
            {
                csvBuilder.AppendLine(GetCsvRow(m));
            }
            return csvBuilder.ToString();
        }
    }
}