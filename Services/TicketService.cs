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

        public Ticket GenerateTicket(Injector injector, Slot freeSlot, Vechile vechile)
        {
            List<Ticket> tickets = injector.ReadTickets();
            DateTime inTime = DateTime.Now;
            Ticket ticket = new Ticket(freeSlot.name, vechile.number, inTime);
            tickets.Add(ticket);
            injector.SaveTickets(tickets);
            return ticket;
        }
        public void DeleteTicket(Injector injector, List<Ticket> tickets, Ticket ticket)
        {
            tickets.Remove(ticket);
            injector.SaveTickets(tickets);
        }

    }
}
