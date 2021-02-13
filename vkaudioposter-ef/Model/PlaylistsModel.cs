using System;
using System.Collections.Generic;
using System.Text;

namespace vkaudioposter_ef.Model
{
    public class Playlist
    {
        public int id { get; set; }
        public string Playlist_ID { get; set; }
        public string Playlist_Name { get; set; }
        public int Mood { get; set; }
    }
}
