using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace vkaudioposter_ef.Model
{
    public partial class SpotyVKUser
    {
        //[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public long VKID { get; set; }
        public bool HasSubscription { get; set; }
    }
}
