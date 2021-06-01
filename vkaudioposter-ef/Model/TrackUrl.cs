using System.ComponentModel.DataAnnotations;
using vkaudioposter_ef.parser;

#nullable enable

namespace vkaudioposter_ef.Model
{
    //[Keyless]
    public partial class TrackUrl
    {
        [Key]
        public int Id { get; set; }
        public string Key { get; set; } = null!;

        public string Value { get; set; } = null!;

        public virtual PostedTrack PostedTrack { get; set; } = null!; //= new PostedTrack { OwnerId = 0 };
    }
}
