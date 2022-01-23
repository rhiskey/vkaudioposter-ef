﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
