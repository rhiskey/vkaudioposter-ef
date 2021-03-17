using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vkaudioposter_ef.Model
{
#nullable enable
    public partial class Role
    {

        [Key]
        [Column("id")]
        public int Id { get; set; }

        public string? Name { get; set; }
        //public DateTime CreatedAt { get; set; }
        //public DateTime UpdatedAt { get; set; }
        public virtual User User { get; set; }
        //public virtual ICollection<User> Users { get; set; }
    }
}
