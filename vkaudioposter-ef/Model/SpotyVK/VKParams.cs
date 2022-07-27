using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace vkaudioposter_ef.Model.SpotyVK
{
    public partial class VKParams
    {
        [Key]
        public int Id { get; set; }

        [Comment("Board Topic to track feed")]
        public long TopicId { get; set; }

    }
}
