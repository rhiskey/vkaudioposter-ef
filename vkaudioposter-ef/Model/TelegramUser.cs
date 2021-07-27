
using System.ComponentModel.DataAnnotations;

namespace vkaudioposter_ef.Model
{
    public partial class TelegramUser
    {
        [Key]
        public int Id { get; set; }

        public string UUID { get; set; }
        public long ChatId { get; set; }

    }
}
