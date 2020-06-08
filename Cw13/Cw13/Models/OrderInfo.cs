using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw13.Models
{
    public class OrderInfo
    {
        public int IdZamowienia { get; set; }
        public int IdKlienta { get; set; }
        public DateTime DataPrzyjecia { get; set; }
        public Nullable<DateTime> DataRealizacji { get; set; }
        public string Uwagi { get; set; }

        /*
         * TUTAJ PROBLEM: kiedy chcę zwrócić listę w JSONie dostaje błąd JsonException:
         * A possible object cycle was detected which is not supported.
         * This can either be due to a cycle or if the object depth is larger than the maximum allowed depth of 32.
         */
        public ICollection<ProductInfo> WyrobyCukiernicze { get; set; }
    }
}
