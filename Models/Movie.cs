using System;

namespace MovieDump.Models
{
    public class Movie
    {
        public string Title { get; set; }
        public long Size { get; set; }
        public string Format { get; set; }
        public string LibraryName { get; set; }
        public string Year { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Duration { get; set; }
        public string Bitrate { get; set; }
        public string Container { get; set; }
        public string VideoCodec { get; set; }
        public string AudioCodec { get; set; }
        public string AudioChannels { get; set; }
        public decimal FramesPerSecond { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}