using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Classes
{
    [PrimaryKey(nameof(CodCititor))]
    internal class Cititori
    {
        public int CodCititor { get; set; }
        public string NumeCititor { get; set; }
        public ICollection<Carti> Carti { get; } = new List<Carti>();
        public DateTime DateChirie { get; set; }
    }
}
