using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        //public virtual Playlist Playlist { get; set; }
    }
}
