using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocaAmigos.Models
{
    public class Usuario:Entidade
    {
        public string email { get; set; }
        public string senha { get; set; }
        public bool ativo { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}
