using ParkingLot.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingLot.Models;
using System.Net.Sockets;

namespace ParkingLot.Injectors
{
    class Injector
    {
        public IParkingLotService parkingLotService;
        public ITicketService ticketService;
        public Injector(IParkingLotService parkingLotService, ITicketService ticketService)
        {
            this.parkingLotService = parkingLotService;
            this.ticketService = ticketService;
        }



        // ParkingLotService methods
        public List<Slot> ReadSlots()
        {
            return parkingLotService.ReadSlots();
        }

        public Boolean SaveSlots(List<Slot> slots)
        {
            return parkingLotService.SaveSlots(slots);
        }

        public List<Slot> InitializeLot(int twoWheelerSlots, int fourWheelerSlots, int heavyVechileSlots)
        {
            return parkingLotService.InitializeLot(this, twoWheelerSlots, fourWheelerSlots, heavyVechileSlots);
        }

        public string ParkVechile(List<Slot> slots, Vechile vechile)
        {
            return parkingLotService.ParkVechile(this, slots, vechile);
        }

        public string UnParkVechile(List<Slot> slots, string number)
        {
            return parkingLotService.UnParkVechile(this, slots, number);
        }



        ///TicketService methods
        public List<Ticket> ReadTickets()
        {
            return ticketService.ReadTickets();
        }
        public Boolean SaveTickets(List<Ticket> tickets)
        {
            return ticketService.SaveTickets(tickets);
        }
        public Ticket GenerateTicket(Slot freeSlot, Vechile vechile)
        {
            return ticketService.GenerateTicket(this, freeSlot, vechile);
        }
        public void DeleteTicket(List<Ticket> tickets, Ticket ticket)
        {
            ticketService.DeleteTicket(this, tickets, ticket);
        }

    }
}
