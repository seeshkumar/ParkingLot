using Newtonsoft.Json;
using ParkingLot.Interfaces;
using ParkingLot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingLot.Injectors;

namespace ParkingLot.Services
{
    class TicketService : ITicketService
    {

        public List<Ticket> ReadTickets()
        {
            string json = File.ReadAllText("./assets/Tickets.json");
            return JsonConvert.DeserializeObject<List<Ticket>>(json);
        }

        public Boolean SaveTickets(List<Ticket> tickets)
        {
            try
            {
                string json = JsonConvert.SerializeObject(tickets);
                File.WriteAllText("./assets/Tickets.json", json);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        void ITicketService.DeleteTicket(Injector injector, List<Ticket> tickets, Ticket ticket)
        {
            throw new NotImplementedException();
        }

        Ticket ITicketService.GenerateTicket(Injector injector, Slot freeSlot, Vechile vechile)
        {
            throw new NotImplementedException();
        }
    }
}
