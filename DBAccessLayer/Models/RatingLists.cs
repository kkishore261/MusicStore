using System;
using System.Collections.Generic;

namespace DBAccessLayer.Models
{
    public partial class RatingLists
    {
        public decimal RatingId { get; set; }
        public decimal? Rating { get; set; }
        public DateTime? CreatedDate { get; set; }
        public decimal? AlbumId { get; set; }
        public decimal? TrackId { get; set; }

        public AlbumLists Album { get; set; }
    }
}
