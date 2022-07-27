using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace vkaudioposter_ef.Model
{
    public partial class VKAccounts
    {
        [Key]
        public int Id { get; set; }

        public string VKLogin { get; set; }
        public string VKPassword { get; set; }

        [Comment("Can user auth?")]
        public bool Status { get; set; }
    }
}
