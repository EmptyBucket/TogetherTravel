using System.ComponentModel.DataAnnotations;

namespace TogetherTravel.ViewModels
{
    public class RegistrationUserViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Пароль и его подтверждение не совпадает")]
        public string ConfirmPassword { get; set; }
    }
}