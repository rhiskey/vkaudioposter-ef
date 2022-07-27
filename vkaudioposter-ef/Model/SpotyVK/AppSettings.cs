using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vkaudioposter_ef.Model.SpotyVK
{
    public partial class AppSettings
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Comment("Spotify Uri to play if no playing context")]
        public string DefaultUri { get; set; }

        [Comment("Ad image url to load in card")]
        public string AdImageUrl { get; set; }

        [Comment("Ad link, on tap open")]
        public string AdUrl { get; set; }

        [Comment("Ad text on card")]
        
        public string AdText { get; set; }

        [Comment("Ad text on card")]
        public string AdTextSecond { get; set; }
    }
}
