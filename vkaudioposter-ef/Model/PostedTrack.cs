using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Column(TypeName = "nvarchar(1024)")]
        [MaxLength(1024)]
        //[Index(IsUnique = true)]
        public string Trackname { get; set; } = null!; //= "Trackname"; 

        ////[Required]
        //[Column(TypeName = "varchar(45)")]
        //[MaxLength(50)]
        //public string? Style { get; set; }

        [Column(TypeName = "DATETIME")]
        public DateTime Date { get; set; }

        public int? PlaylistId { get; set; }

        public long? OwnerId { get; set; }
        public long? MediaId { get; set; }

        //[Column("Urls"), JsonExtensionData]
        //public Dictionary<string, string>? Urls { get; set; }

        [NotMapped] //COMMENT if want to store in DB
        public IList<TrackUrl>? TrackUrls { get; set; }

        public string? Url { get; set; }
        public string? PreviewUrl { get; set; }

        public virtual Playlist Playlist { get; set; } = null!; //= new Playlist { PlaylistName = "Default" };
        public virtual Post? Post { get; set; }


    }

}
