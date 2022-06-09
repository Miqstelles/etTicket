using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pinegas.Data.ViewModels
{
    public class RegisterVM
    {
        public string FullName { get; set; }
        [Required(ErrorMessage = "Digite um email!")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite uma senha!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "As senhas estão diferentes!")]
        public string ConfirmPassword { get; set; }
    }
}
