using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//#nullable enable

namespace vkaudioposter_ef.Model
{
    public partial class Configuration
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        public string SpotifyClientId { get; set; }
        [Required]
        public string SpotifyClientSecret { get; set; }

        [Comment("Postponed post addition time")]
        public int HoursPeriod { get; set; }
        [Comment("Postponed post time")]
        public int MinutesPeriod { get; set; }

        [Comment("add tracks to attachments =добавить фото и музыку вложения на стену. Приложение группы доступ к группе, получается в самом приложении в ручную Standalone приложение")]
        public string AccessToken { get; set; }

        public string KateMobileToken { get; set; }
        [Comment("Загрузка фото + публикация треков (сделать через свое приложение)")]

        public string Token { get; set; }

        public string UserAccesToken { get; set; }

        [Comment("Search vk tracks api")]
        public string ApiUrl { get; set; }

        [Comment("VK account")]
        public int OwnerId { get; set; }

        [Comment("VK community id")]
        public int GroupId { get; set; }

        [Comment("VK account to send log messages")]
        public int AdminId { get; set; }

        public string TorHost { get; set; }
        public int TorPort { get; set; }
        //public string RabbitHost { get; set; }

        public bool SaveLogs { get; set; }
        public bool FirstRun { get; set; }
        public bool UseProxy { get; set; }
        public bool Debug { get; set; }

        public bool StartOnce { get; set; }
        public string RollbarToken { get; set; }

        [Comment("SignalR Hub")]
        public string ConsoleHub { get; set; }
        public string VKLogin { get; set; }
        public string VKPassword { get; set; }
    }
}
