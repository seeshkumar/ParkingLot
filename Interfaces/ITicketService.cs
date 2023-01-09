using ParkingLot.Injectors;
using ParkingLot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Interfaces
{
    interface ITicketService
    {
        public List<Ticket> ReadTickets();
        public Boolean SaveTickets(List<Ticket> tickets);
        public Ticket GenerateTicket(Injector injector, Slot freeSlot, Vechile vechile);
        public void DeleteTicket(Injector injector, List<Ticket> tickets, Ticket ticket);

    }
}
