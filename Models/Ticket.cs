using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Models
{
    class Ticket
    {
        public string slotName { get; set; }
        public string vechileNumber { get; set; }
        public DateTime inTime { get; set; }
        public DateTime outTime { get; set; }

        public Ticket(string slotName, string vechileNumber, DateTime inTime)
        {
            this.slotName = slotName;
            this.vechileNumber = vechileNumber;
            this.inTime = inTime;
        }

    }
}
