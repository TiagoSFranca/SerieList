using System.ComponentModel.DataAnnotations;

namespace SerieList.Presentation.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Usuário ou Email")]
        public string UserNameOrEmail { get; set; }

        [Required]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Manter Conectado")]
        public bool KeepConnected { get; set; }
    }
}