using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocaAmigos.Models.DVO
{
    public class LocacaoVO
    {
        public Jogos Jogo { get; set; }
        public Pessoa Amigo{ get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
    }
}
