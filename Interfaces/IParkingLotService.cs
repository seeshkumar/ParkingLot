using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingLot.Models;
using ParkingLot.Injectors;

namespace ParkingLot.Interfaces
{
    interface IParkingLotService
    {
        public List<Slot> ReadSlots();
        public Boolean SaveSlots(List<Slot> slots);
        public List<Slot> InitializeLot(Injector injector, int twoWheelerSlots, int fourWheelerSlots, int heavyVechileSlots);

        public string ParkVechile(Injector injector, List<Slot> slots, Vechile vechile);
        public string UnParkVechile(Injector injector, List<Slot> slots, string number);
    }
}
