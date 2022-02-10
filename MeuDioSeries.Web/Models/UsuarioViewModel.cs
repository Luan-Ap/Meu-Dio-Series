using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeuDioSeries.Web.Models
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage = "Preencha o campo Usuário")]
        [Display(Name = "Usuário")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Preencha o campo Senha")]
        [MinLength(3, ErrorMessage = "Senha precisa ter, no mínimo, 3 caracteres")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name = "Lembrar-me")]
        public bool LembrarMe { get; set; }
    }
}
