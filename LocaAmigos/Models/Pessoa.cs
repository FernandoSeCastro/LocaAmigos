using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocaAmigos.Models
{
    public class Pessoa : Entidade
    {
        public string nome { get; set; }
        public string nomecompleto { get; set; }
        public DateTime datanascimento { get; set; }
        
    }
}
