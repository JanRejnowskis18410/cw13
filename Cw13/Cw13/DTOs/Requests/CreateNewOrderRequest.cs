using System;
using System.ComponentModel.DataAnnotations;

namespace Cw13.DTOs.Requests
{
    public class CreateNewOrderRequest
    {
        [Required(ErrorMessage = "Brak wymaganego pola: dataPrzyjęcia!")]
        public DateTime dataPrzyjecia { get; set; }
        [MaxLength(300, ErrorMessage = "Tekst z uwagami jest za długi! Max. dopuszczalna liczba znaków: 300")]
        public string uwagi { get; set; }
        [Required(ErrorMessage = "Brak wymaganego pola: wyroby!")]
        public Wyrob[] wyroby { get; set; }
        [Required(ErrorMessage = "Brak wymaganego pola: idPracownika!")]
        public int idPracownika { get; set; }
    }

    public class Wyrob
    {
        public int ilosc { get; set; }
        public string wyrob { get; set; }
        public string uwagi { get; set; }
    }
}
