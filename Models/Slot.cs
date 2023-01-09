using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Models
{
    class Slot
    {
        public string name { get; set; }
        public string category { get; set; }
        public Boolean isOccupied { get; set; }


        public Slot(string name, string category, bool occupied)
        {
            this.name = name;
            this.category = category;
            this.isOccupied = occupied;
        }
    }
}
