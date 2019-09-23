using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using Dapper;
using MovieDump.Models;
using System.Linq;

namespace MovieDump.DataAccess
{
    public class PlexDbDataAccess
    {
        private readonly IDbConnection _conn;
        public PlexDbDataAccess(string connString)
        {
            this._conn = new SQLiteConnection(connString);
        }

        public IEnumerable<Movie> GetMovies()
        {
            var res = new List<Movie>();
            var moviesQuery =@"SELECT lib.name as libraryname, meta.title, meta.year, mp.size, CASE media.height WHEN 480 THEN 'DVD' WHEN 2160 THEN '4K' ELSE 'BLU-RAY' END AS format
	, media.width, media.height, media.duration, media.bitrate, media.container, media.video_codec as videocodec, media.audio_codec as audiocodec
    , media.audio_channels as audiochannels, media.frames_per_second as framespersecond, media.created_at as createdate, media.updated_at as lastupdated
FROM media_items media
INNER JOIN library_sections lib ON media.library_section_id = lib.id
INNER JOIN metadata_items as meta ON media.metadata_item_id = meta.id
LEFT OUTER JOIN media_parts mp on media.id = mp.media_item_id
WHERE meta.parent_id IS NULL;
";

            using(IDbConnection conn = _conn)
            {
                conn.Open();
                res = conn.Query<Movie>(moviesQuery).ToList();
            }

            return res.OrderBy(m => m.Title).ThenBy(x => x.Year);
        }
    }
}