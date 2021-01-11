using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LocaAmigos.Models
{
    public class Entidade
    {
        public int id { get; set; }
        [Display(Name ="Criado")]
        public DateTime created { get; set; }
        public DateTime? update { get; set; }
        public DateTime? remove { get; set; }
    }
}
