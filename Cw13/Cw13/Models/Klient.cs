using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw13.Models
{
    public class Klient
    {
        public int IdKlient { get; set; }
        public String Imie { get; set; }
        public String Nazwisko { get; set; }
        public virtual ICollection<Zamowienie> Zamowienia { get; set; }
    }
}
