using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace vkaudioposter_ef.Model
{
    [Table("PostedPhotos")]
    public partial class PostedPhoto
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(2056)")]
        [MaxLength(2056)]
        public string Url { get; set; }

        public int? PostId { get; set; }
        public virtual Post Post { get; set; }

    }
}
