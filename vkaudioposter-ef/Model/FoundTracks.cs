using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vkaudioposter_ef.Model
{
    public partial class FoundTracks
    {
        [Key]
        public int Id { get; set; }

        [Comment("Fulltrackname")]
        /// For MSSQL
        //[Column(TypeName = "nvarchar(1024)")]
        //[MaxLength(1024)]
        public string Trackname { get; set; } = null!;
        public long? MediaId { get; set; }
        public long? OwnerId { get; set; }
    }
}
