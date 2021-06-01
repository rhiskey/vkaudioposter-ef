using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using vkaudioposter_ef.Model;

#nullable disable

namespace vkaudioposter_ef.parser
{
    [Table("console_Photostocks")]
    public partial class ConsolePhotostock
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("URL", TypeName = "varchar(200)")]
        [Required]
        [MaxLength(200)]
        public string Url { get; set; }

        [Comment("Enabled status. If = 0 - not included, if = 1 - included in parsing")]
        public int Status { get; set; }
        [Comment("Update Date")]
        public DateTime UpdateDate { get; set; }
        //public int? ParserXpathId { get; set; }
        //[ForeignKey("ParserXpathId")]
        //public virtual ParserXpath ParserXpath { get; set; }
        //public virtual Playlist Playlist { get; set; }
    }
}
