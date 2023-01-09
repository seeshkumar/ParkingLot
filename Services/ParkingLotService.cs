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


        public List<Slot> InitializeLot(Injector injector, int twoWheelerSlots, int fourWheelerSlots, int heavyVechileSlots)
        {

            List<Slot> slots = new List<Slot>();
            string name;
            for (int i = 0; i < twoWheelerSlots; i++)
            {
                name = $"TWO{i + 1}";
                slots.Add(new Slot(name, "2Wheeler", false));
            }

            for (int i = 0; i < fourWheelerSlots; i++)
            {
                name = $"FOUR{i + 1}";
                slots.Add(new Slot(name, "4Wheeler", false));
            }

            for (int i = 0; i < heavyVechileSlots; i++)
            {
                name = $"HEAVY{i + 1}";
                slots.Add(new Slot(name, "HEAVY", false));
            }
            injector.SaveSlots(slots);
            injector.SaveTickets(new List<Ticket>());//clearing tickets db
            return slots;
        }

        string IParkingLotService.ParkVechile(Injector injector, List<Slot> slots, Vechile vechile)
        {
            throw new NotImplementedException();
        }

        string IParkingLotService.UnParkVechile(Injector injector, List<Slot> slots, string number)
        {
            throw new NotImplementedException();
        }
    }
}
