using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable

namespace vkaudioposter_ef.parser
{
    public partial class Configuration
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column(TypeName = "DATETIME")]
        public DateTime PostponedDate { get; set; }

    }
}
