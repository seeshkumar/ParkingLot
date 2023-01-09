using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Models
{
    class Vechile
    {
        public string number { get; set; }
        public string category { get; set; }

        public Vechile(string number, string category)
        {
            this.number = number;
            this.category = category;
        }
    }
}
