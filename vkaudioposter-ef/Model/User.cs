using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vkaudioposter_ef.Model
{
#nullable enable
    public partial class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        //public DateTime CreatedAt { get; set; }
        //public DateTime UpdatedAt { get; set; }
        public virtual ICollection<Role> Roles { get; set; } = new List<Role> { new Role { Name = "Default Role" } };
    }
}
