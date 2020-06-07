using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw13.Models
{
    public class Pracownik
    {
        public int IdPracownik { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public virtual ICollection<Zamowienie> Zamowienia { get; set; }
    }
}
