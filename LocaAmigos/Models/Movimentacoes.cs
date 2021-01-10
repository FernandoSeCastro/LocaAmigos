using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocaAmigos.Models
{
    public class Movimentacoes : Entidade
    {
        public DateTime inicio { get; set; }
        public DateTime fim { get; set; }
        public bool ativo { get; set; }
        public Jogos Jogos { get; set; }
        public Pessoa Pessoa { get; set; }
        public Usuario Usuario { get; set; }
    }
}
