using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ParkingLot.Injectors;
using ParkingLot.Interfaces;
using ParkingLot.Models;


namespace ParkingLot.Services
{
    class ParkingLotService : IParkingLotService
    {


        public List<Slot> ReadSlots()
        {
            string slotsJson = File.ReadAllText("./assets/slots.json");
            List<Slot> slots = JsonConvert.DeserializeObject<List<Slot>>(slotsJson);
            return slots;

        }

        public Boolean SaveSlots(List<Slot> slots)
        {
            try
            {
                string json = JsonConvert.SerializeObject(slots);
                File.WriteAllText("./assets/Slots.json", json);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public List<Slot> InitializeLot(Injector injector, int twoWHEELERSlots, int fourWHEELERSlots, int heavyVechileSlots)
        {

            List<Slot> slots = new List<Slot>();
            string name;
            for (int index = 0; index < twoWHEELERSlots; index++)
            {
                name = $"TWO{index + 1}";
                slots.Add(new Slot(name, "TWOWHEELER", false));
            }

            for (int index = 0; index < fourWHEELERSlots; index++)
            {
                name = $"FOUR{index + 1}";
                slots.Add(new Slot(name, "FOURWHEELER", false));
            }

            for (int index = 0; index < heavyVechileSlots; index++)
            {
                name = $"HEAVY{index + 1}";
                slots.Add(new Slot(name, "HEAVY", false));
            }
            injector.SaveSlots(slots);
            injector.SaveTickets(new List<Ticket>());//clearing tickets db
            return slots;
        }

        public string ParkVechile(Injector injector, List<Slot> slots, Vechile vechile)
        {

            Slot freeSlot = slots.FirstOrDefault(s => s.category == vechile.category && s.isOccupied == false);
            if (freeSlot == null)
            {
                return "No slots available";
            }

            freeSlot.isOccupied = true;
            injector.SaveSlots(slots);
            Ticket ticket = injector.GenerateTicket(freeSlot, vechile);
            //ticket string
            return $"VECHILE NUMBER : {ticket.vechileNumber} \nSLOT NAME : {ticket.slotName} \nIN TIME : {ticket.inTime} \nOUT TIME : -";
        }

        public string UnParkVechile(Injector injector, List<Slot> slots, string number)
        { 

            List<Ticket> tickets = injector.ReadTickets();

            Ticket ticket = tickets.FirstOrDefault(t => t.vechileNumber == number);
            if (ticket == null)
            {
                return "Vechile not found";
            }
            slots.FirstOrDefault(s => s.name == ticket.slotName).isOccupied = false;
            injector.SaveSlots(slots);

            DateTime outTime = DateTime.Now;
            string msg = $"VECHILE NUMBER : {ticket.vechileNumber} \nSLOT NAME : {ticket.slotName} \nIN TIME : {ticket.inTime} \nOUT TIME : {outTime}";

            injector.DeleteTicket(tickets, ticket);

            return msg;
        }
    }
}
