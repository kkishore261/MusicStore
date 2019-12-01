using System;
using System.Collections.Generic;

namespace DBAccessLayer.Models
{
    public partial class TrackLists
    {
        public decimal TrackId { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string Time { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateModified { get; set; }
        public decimal? TrackCount { get; set; }
        public decimal? AlbumId { get; set; }

        public AlbumLists Album { get; set; }
    }
}
