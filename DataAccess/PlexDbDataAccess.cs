using System.Collections.Generic;
using System.Data.SQLite;
using Dapper;
using MovieDump.Models;

namespace MovieDump.DataAccess
{
    public class PlexDbDataAccess
    {
        private const string moviesQuery = @"
SELECT
    meta.title AS [Title],
    meta.year AS [Year],
    CASE media.height WHEN 480 THEN 'DVD' WHEN 2160 THEN '4K' ELSE 'BLU-RAY' END AS [Format],
    media.duration AS [Duration],
    media.video_codec AS [VideoCodec],
    media.audio_codec AS [AudioCodec],
    mp.size / 1048576 AS [SizeMB]
FROM media_items AS media
    INNER JOIN library_sections AS lib ON media.library_section_id = lib.id
    INNER JOIN metadata_items AS meta ON media.metadata_item_id = meta.id
    LEFT OUTER JOIN media_parts AS mp ON media.id = mp.media_item_id
WHERE meta.parent_id IS NULL
ORDER BY meta.title, meta.year, media.video_codec, media.audio_codec
";

        private readonly string _connString;

        public PlexDbDataAccess(string connString)
        {
            this._connString = connString;
        }

        public IEnumerable<Movie> GetMovies()
        {
            using (var conn = new SQLiteConnection(_connString))
            {
                conn.Open();
                return conn.Query<Movie>(moviesQuery);
            }
        }
    }
}