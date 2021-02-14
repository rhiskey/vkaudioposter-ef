using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace vkaudioposter_ef.parser
{
    public partial class Playlist
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("Playlist_ID")]
        public string PlaylistId { get; set; }
        [Column("Playlist_Name")]
        public string PlaylistName { get; set; }
        //public string PlaylistAuthor { get; set; }
        public int Mood { get; set; }
        public string Photostock { get; set; }
    }
}
