using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LocaAmigos.Models
{
    public class Jogos : Entidade
    {
        [Display(Name = "Nome")]
        public string nome { get; set; }
        [Display(Name = "Tipo do Jogo")]
        public string tipojogo { get; set; }
        [Display(Name = "Liberado")]
        public bool ativo { get; set; }
    }
}
