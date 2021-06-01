using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using vkaudioposter_ef.parser;

#nullable enable
namespace vkaudioposter_ef.Model
{
    public partial class Track
    {
        //[Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(150)")]
        [MaxLength(150)]
        public string Trackname { get; set; } = null!;

        ////[Required]
        //[Column(TypeName = "varchar(45)")]
        //[MaxLength(50)]
        //public string? Style { get; set; }

        public int? PlaylistId { get; set; }
        public virtual Playlist Playlist { get; set; } = null!;
    }
}
