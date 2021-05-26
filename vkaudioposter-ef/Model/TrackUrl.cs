using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable enable

namespace vkaudioposter_ef.Model
{
    [Keyless]
    public partial class TrackUrl
    {
        public string Key { get; set; }

        public string Value { get; set; }
    }
}
