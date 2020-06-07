using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw13.Models
{
    public class Zamowienie_WyrobCukierniczy
    {
        public Zamowienie Zamowienie { get; set; }
        public WyrobCukierniczy WyrobCukierniczy { get; set; }
        public int IdWyrobuCukierniczego { get; set; }
        public int IdZamowienia { get; set; }
        public int Ilosc { get; set; }
        public string Uwagi { get; set; }
    }
}
