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
        
        [Comment("add tracks to attachments добавить фото и музыку вложения. Приложение группы доступ к группе, получается в самом приложении в ручную Standalone приложение")]
        public string AccessToken { get; set; }
        public string VKCommunityAccessTokenProd { get; set; }

        [Comment("Anticaptcha secret key")]
        public string AntiCaptchaSecretKey { get; set; }
    }
}
