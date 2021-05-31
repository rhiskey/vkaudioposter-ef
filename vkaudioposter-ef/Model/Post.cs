using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vkaudioposter_ef.parser;

namespace vkaudioposter_ef.Model
{
    [Table("Posts")]
    public partial class Post
    {
        [Key]
        public int Id { get; set; }

        public long PostId { get; set; }

        public string Message { get; set; }

        [Column(TypeName = "DATETIME")]
        public DateTime PublishDate { get; set; }

        public long? OwnerId { get; set; }
        //[JsonIgnore]
        public virtual ICollection<PostedTrack> PostedTracks { get; set; }

        //[JsonIgnore]
        public virtual ICollection<PostedPhoto> PostedPhotos { get; set; }
    }
}
