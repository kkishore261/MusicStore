using System;
using System.Collections.Generic;

namespace DBAccessLayer.Models
{
    public partial class Genres
    {
        public Genres()
        {
            AlbumLists = new HashSet<AlbumLists>();
        }

        public decimal GenreId { get; set; }
        public string Name { get; set; }

        public ICollection<AlbumLists> AlbumLists { get; set; }
    }
}
