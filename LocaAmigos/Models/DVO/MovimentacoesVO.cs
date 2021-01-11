using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LocaAmigos.Models.DVO
{
    public class MovimentacoesVO
    {
        [Display(Name = "Inicio")]
        public DateTime inicio { get; set; }
        [Display(Name = "Fim")]
        public DateTime fim { get; set; }

        [Required]
        [Display(Name = "Selecione Jogo")]
        public string JogosId { get; set; }
        public List<Jogos> ListaJogos { get; set; }

        [Required]
        [Display(Name = "Selecione o Amigo")]
        public string PessoaId { get; set; }
        public List<Pessoa> ListaPessoas { get; set; }
    }
}
