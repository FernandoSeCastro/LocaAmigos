using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LocaAmigos.Models.DVO
{
    public class UsuarioLoginVO
    {
        [Required(ErrorMessage = "Email necesário")]
        public string email { get; set; }
        [Required(ErrorMessage = "Senha necessária")]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string senha { get; set; }
    }
}
