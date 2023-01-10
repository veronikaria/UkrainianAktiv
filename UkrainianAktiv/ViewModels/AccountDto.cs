using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UkrainianAktiv.ViewModels
{
    public class AccountDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Невірно заповнене поле Ім'я")]
        [DisplayName("Введіть ім'я")]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Невірно заповнене поле Пароль")]
        [DataType(DataType.Password)]
        [DisplayName("Введіть пароль")]
        public string Password { get; set; }
    }
}
