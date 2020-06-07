using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cw13.DTOs.Requests
{
    public class CreateNewOrderRequest
    {
        [Required]
        public DateTime dataPrzyjecia { get; set; }
        public string uwagi { get; set; }
        public List<String>[] wyroby { get; set; }
    }
}
