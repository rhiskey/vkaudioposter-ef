using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using vkaudioposter_ef.Model;

#nullable enable

namespace vkaudioposter_ef.parser
{
    [Table("PostedTracks")]
    public partial class PostedTrack
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(1024)")]
        [MaxLength(1024)]
        //[Index(IsUnique = true)]
        public string Trackname { get; set; }

        ////[Required]
        //[Column(TypeName = "varchar(45)")]
        //[MaxLength(50)]
        //public string? Style { get; set; }

        [Column(TypeName = "DATETIME")]
        public DateTime Date { get; set; }

        public int? PlaylistId { get; set; }

        public long? OwnerId { get; set; }
        public long? MediaId { get; set; }

        [Column("Urls"), JsonExtensionData]
        public Dictionary<string, string>? Urls { get; set; }

        public string? Url { get; set; }
        public string? PreviewUrl { get; set; }

        public virtual Playlist Playlist { get; set; }
        public virtual Post? Post { get; set; }
    }
}
