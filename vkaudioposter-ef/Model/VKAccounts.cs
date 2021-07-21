using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
