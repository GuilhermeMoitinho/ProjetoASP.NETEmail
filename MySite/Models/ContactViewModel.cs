using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MySite.Models
{
    public class ContactViewModel
    {
        [DisplayName("Nome")]
        [Required(ErrorMessage = "Campo Nome obrigatorio")]
        [MinLength(3, ErrorMessage = "O nome ter no minimo 3 caracteres")]
        public string Name { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "Campo E-mail obrigatorio")]
        [EmailAddress(ErrorMessage = "E-mail invalido")]
        public string Email { get; set; }
        [DisplayName("Mensagem")]
        [Required(ErrorMessage = "Campo Mensagem obrigatorio")]
        [MinLength(10, ErrorMessage = "O nome ter no minimo 10 caracteres")]
        public string Message { get; set; }
    }
}