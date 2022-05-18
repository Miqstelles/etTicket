using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace etTicket.Data.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Nome completo")]
        [Required(ErrorMessage = "Digite o seu nome completo")]
        public string FullName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Digite o seu email")]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirmar senha")]
        [Required(ErrorMessage = "Confirme sua senha")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "As senhas não combinam")]
        public string ConfirmPassword { get; set; }
    }
}
