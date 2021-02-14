using System;
using System.Collections.Generic;

#nullable disable

namespace vkaudioposter_ef.parser
{
    public partial class VwAllPlaylist
    {
        public string PlaylistId { get; set; }
        public string PlaylistName { get; set; }
        public string PlaylistAuthor { get; set; }
        public int Mood { get; set; }
        public string Photostock { get; set; }
        public int Id { get; set; }
    }
}
