﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace vkaudioposter_ef.parser
{
    public partial class Playlist
    {
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("Playlist_ID",TypeName = "varchar(45)")]
        [MaxLength(45)]
        [Comment("Spotify URI")]
        public string PlaylistId { get; set; }

        [Required]
        [Column("Playlist_Name", TypeName = "varchar(50)")]
        [MaxLength(50)]
        [Comment("Name of playlist")]
        public string PlaylistName { get; set; }

        //public string PlaylistAuthor { get; set; }
        public int Mood { get; set; }
        //public virtual ICollection<ConsolePhotostock> Photostock { get; set; }
        public virtual ICollection<PostedTrack> PostedTracks { get; set; }
        public virtual ICollection<UnfoundTrack> UnfoundTracks { get; set; }
    }
}
