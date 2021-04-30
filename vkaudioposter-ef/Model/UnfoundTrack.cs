using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable

namespace vkaudioposter_ef.parser
{
    [Table("UnfoundTracks")]
    public partial class UnfoundTrack
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("trackname", TypeName = "varchar(150)")]
        [MaxLength(150)]
        public string Trackname { get; set; }

        ////[Required]
        //[Column("style", TypeName = "varchar(45)")]
        //[MaxLength(50)]
        //public string? Style { get; set; }

        public int? PlaylistId { get; set; }
        public virtual Playlist Playlist { get; set; }

    }
}
