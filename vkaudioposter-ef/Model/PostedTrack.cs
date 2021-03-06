using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable

namespace vkaudioposter_ef.parser
{
    public partial class PostedTrack
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(150)")]
        [MaxLength(150)]
        //[Index(IsUnique = true)]
        public string Trackname { get; set; }

        ////[Required]
        //[Column(TypeName = "varchar(45)")]
        //[MaxLength(50)]
        //public string? Style { get; set; }

        [Column(TypeName = "DATETIME")]
        public DateTime Date { get; set; }

        public int? PlaylistId { get; set; }

        public int OwnerId { get; set; }
        public int MediaId { get; set; }
        public virtual Playlist Playlist { get; set; }
    }
}
