using System;

namespace MovieDump.Models
{
    public class Movie
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string Format { get; set; }

        private TimeSpan _duration;
        public string Duration { get { return _duration.ToString(@"hh\:mm\:ss"); } set { _duration = TimeSpan.FromMilliseconds(int.Parse(value)); } }
        public string VideoCodec { get; set; }
        public string AudioCodec { get; set; }
        public int SizeMB { get; set; }
    }
}