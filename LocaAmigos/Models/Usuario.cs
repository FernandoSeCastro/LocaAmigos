using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LocaAmigos.Models
{
    public class Usuario:Entidade
    {
        [Display(Name ="Email")]
        public string email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string senha { get; set; }
        [Display(Name = "Ativo")]
        public bool ativo { get; set; }
        public string roles { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}
