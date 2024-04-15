using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Classes
{
    [PrimaryKey(nameof(CodCarte))]
    internal class Carti
    {
        public int CodCarte { get; set; }
        public string DenumireCarte { get; set; }
        public string NumeAutor { get; set; }
        public double PretCarte { get; set; }
        public DateTime DataEditarii { get; set; }
    }
}
