using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocaAmigos.Models
{
    public class Jogos : Entidade
    {
        public string nome { get; set; }
        public string tipojogo { get; set; }
        public bool ativo { get; set; }
    }
}
