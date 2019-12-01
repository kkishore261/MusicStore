using System;
using System.Collections.Generic;

namespace DBAccessLayer.Models
{
    public partial class AlbumLists
    {
        public AlbumLists()
        {
            RatingLists = new HashSet<RatingLists>();
            TrackLists = new HashSet<TrackLists>();
        }

        public decimal AlbumId { get; set; }
        public string AlbumName { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public decimal? ArtistId { get; set; }
        public decimal? GenreId { get; set; }
        public string Duration { get; set; }

        public ArtistsList Artist { get; set; }
        public Genres Genre { get; set; }
        public ICollection<RatingLists> RatingLists { get; set; }
        public ICollection<TrackLists> TrackLists { get; set; }
    }
}
