using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LocaAmigos.Models
{
    public class Pessoa : Entidade
    {
        [Display(Name ="Nome")]
        public string nome { get; set; }
        [Display(Name ="Nome Completo")]
        public string nomecompleto { get; set; }
        [Display(Name = "Nascimento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime datanascimento { get; set; }
        
    }
}
