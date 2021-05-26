using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vkaudioposter_ef.parser;

#nullable enable

namespace vkaudioposter_ef.Model
{
    //[Keyless]
    public partial class TrackUrl
    {
        [Key]
        public int Id { get; set; }
        public string Key { get; set; }

        public string Value { get; set; }

        public virtual PostedTrack PostedTrack { get; set; }
    }
}
