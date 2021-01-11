using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LocaAmigos.Models.DVO
{
    public class PessoaVO:Entidade
    {
        public string Nome { get; set; }
        [Display(Name ="Nome Completo")]
        public string NomeCompleto { get; set; }
        [Display(Name = "Nascimento")]
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        public bool Ativo { get; set; }
    }
}
