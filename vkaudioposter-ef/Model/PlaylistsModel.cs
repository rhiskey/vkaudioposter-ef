using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace vkaudioposter_ef.Model
{
    public class Playlist:AllPlaylists
    {
        //public new int Id { get; set; }
        //public new string Playlist_ID { get; set; }
        //public new string Playlist_Name { get; set; }
        public int Mood { get; set; }
    }

    public abstract class AllPlaylists
    {
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(45)")]
        [MaxLength(45)]
        [Comment("Spotify URI")]
        public string Playlist_ID { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        [MaxLength(50)]
        [Comment("Name of playlist")]
        public string Playlist_Name { get; set; }
    }
}
