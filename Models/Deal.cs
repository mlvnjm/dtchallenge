using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealerTrack.Models
{
    public class Deal
    {
        public int DealNumber { get; set; }
        public string CustomerName { get; set; }
        public string DealershipName { get; set; }
        public string Vehicle { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }

        public Deal()
        {
            CustomerName = string.Empty;
            DealershipName = string.Empty;
            Vehicle = string.Empty;
            Date = DateTime.MinValue;
        }
    }
}
