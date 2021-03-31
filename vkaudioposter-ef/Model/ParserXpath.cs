using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using vkaudioposter_ef.parser;
using Microsoft.EntityFrameworkCore;

#nullable disable
namespace vkaudioposter_ef.Model
{
    public partial class ParserXpath
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Comment("nodContainer for parsing (outer)")]
        [MaxLength(1024)]
        public string Xpath { get; set; }
        [Comment("nodContainer for parsing (inner if need to go inside)")]
        [MaxLength(1024)]
        public string XpathInner { get; set; }
        public virtual List<ConsolePhotostock> ConsolePhotostock { get; set; }
    }
}
