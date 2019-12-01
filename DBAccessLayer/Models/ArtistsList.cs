using System;
using System.Collections.Generic;

namespace DBAccessLayer.Models
{
    public partial class ArtistsList
    {
        public ArtistsList()
        {
            AlbumLists = new HashSet<AlbumLists>();
        }

        public decimal ArtistId { get; set; }
        public string ArtistName { get; set; }
        public string Description { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastupdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string Price { get; set; }

        public ICollection<AlbumLists> AlbumLists { get; set; }
    }
}
