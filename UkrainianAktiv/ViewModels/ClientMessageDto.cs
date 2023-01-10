using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UkrainianAktiv.ViewModels
{
    public class ClientMessageDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле Ім'я не заповнено")]
        [StringLength(50, ErrorMessage = "Поле Ім'я містить більше 50 символів")]
        [DataType(DataType.Text)]
        [DisplayName("Ім'я *")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле Email не заповнено")]
        [EmailAddress(ErrorMessage = "Невірно заповнено поле Email")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email *")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [DisplayName("Телефон")]
        public string Phone { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле Повідомлення не заповнено")]
        [StringLength(1000, ErrorMessage = "Поле Повідомлення містить більше 1000 символів")]
        [DataType(DataType.MultilineText)]
        [DisplayName("Повідомлення *")]
        public string MessageText { get; set; }
    }
}
