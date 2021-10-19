using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vkaudioposter_ef.Model
{
    public partial class SpotyToVkShareBackendConfig
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        public string SpotifyClientId { get; set; }
        [Required]
        public string SpotifyClientSecret { get; set; }
        public string RollbarBackendToken { get; set; }

        public string VKCommunityAccessTokenProd { get; set; }
        [Comment("Загрузка треков")]
        public string KateMobileToken { get; set; }
        [Comment("VK community id")]
        public ulong GroupIdSpotyShare { get; set; }

        [Comment("Anticaptcha secret key")]
        public string AntiCaptchaSecretKey { get; set; }
    }
}
