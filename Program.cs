using ParkingLot.Injectors;
using ParkingLot.Models;
using ParkingLot.Services;
using System.Runtime.CompilerServices;

class Program
{
    public static void Main(String[] args)
    {
        int mode;
        ParkingLotService parkingLotService = new ParkingLotService();
        TicketService ticketService = new TicketService();
        Injector injector = new Injector(parkingLotService, ticketService);
        List<Slot> slots;
        List<Ticket> tickets;


        Console.WriteLine("1.Initialize a parking lot.\n2.See Parking Lot current occupancy details.\n3.Park Vehicle and Issue Ticket.\n4.Un-park Vehicle.   :");
        mode = Convert.ToInt32(Console.ReadLine());


        switch (mode)
        {
            case 1:
                Console.WriteLine("-------- Initializing Lot --------");
                Console.Write("Number of 2 wheeler slots : ");
                int twoWheelerSlots = Convert.ToInt32(Console.ReadLine());
                Console.Write("Number of 4 wheeler slots : ");
                int fourWheelerSlots = Convert.ToInt32(Console.ReadLine());
                Console.Write("Number of heavy vechile slots : ");
                int heavyVechileSlots = Convert.ToInt32(Console.ReadLine());
                slots = injector.InitializeLot(twoWheelerSlots, fourWheelerSlots, heavyVechileSlots);
                Console.WriteLine("Initialized Slots");
                break;
            case 2:
                slots = injector.ReadSlots();
                tickets = injector.ReadTickets();
                foreach (Slot slot in slots)
                {
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine($"SLOT : {slot.name}\nSLOT CATEGORY : {slot.category}");
                    if (slot.occupied == false)
                    {
                        Console.WriteLine("-- EMPTY SLOT --");
                    }
                    else
                    {
                        Console.WriteLine($"OCCUPIED BY : {tickets.FirstOrDefault(t => t.slotName == slot.name).vechileNumber}");
                    }
                    Console.WriteLine("--------------------------------------");
                }
                break;
            case 3:
                break;
            case 4:
                break;
            default:
                break;

        }







    }
}