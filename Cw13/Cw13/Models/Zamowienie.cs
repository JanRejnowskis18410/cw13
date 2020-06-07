using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw13.Models
{
    public class Zamowienie
    {
        public int IdZamowienia { get; set; }
        public DateTime DataPrzyjecia { get; set; }
        public System.Nullable<DateTime> DataRealizacji { get; set; }
        public string Uwagi { get; set; }
        public int IdKlient { get; set; }
        public int IdPracownik { get; set; }
        public virtual Pracownik Pracownik { get; set; }
        public virtual Klient Klient { get; set; }
        public virtual ICollection<Zamowienie_WyrobCukierniczy> Zamowienia_WyrobyCukiernicze { get; set; }
    }
}
