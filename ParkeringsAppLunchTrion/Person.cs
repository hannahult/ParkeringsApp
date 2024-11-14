using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ParkeringsAppLunchTrion
{
    public class Person
    {
        public static void ParkingmanView(List<Vehicle> vehicles, Income income)
        {
            bool exit = false;

            while (exit == false)
            {
                vehicles = vehicles.OrderBy(v => v.ParkingSpot).ToList();

                foreach (Vehicle vehicle in vehicles)
                {
                    if (vehicle.ParkingTime == 0)
                    {
                        Console.WriteLine("Tiden är ute för fordon " + vehicle.RegNr + " på plats " + (vehicle.ParkingSpot + 1));
                    }

                }

                foreach (Vehicle vehicle in vehicles)
                {

                    Console.Write("\nPlats\t" + (vehicle.ParkingSpot + 1) + (vehicle is Bus ? " & " + (vehicle.ParkingSpot + 2) : "") + "\t" + vehicle.GetType().Name + "\t" + vehicle.RegNr + "\t" + vehicle.Color + "\t");


                    if (vehicle is Car && ((Car)vehicle).Electric == true)
                    {
                        Console.Write("Elbil");
                    }
                    else if (vehicle is Car && ((Car)vehicle).Electric == false)
                    {
                        Console.Write("Bil");
                    }
                    else if (vehicle is Bus)
                    {
                        Console.Write(((Bus)vehicle).NrSeats);
                    }
                    else if (vehicle is MC)
                    {
                        Console.Write(((MC)vehicle).Brand);
                    }

                    TimeSpan timeSpan = vehicle.EndTime - DateTime.Now;
                    int time = (int)timeSpan.TotalSeconds;

                    if (time > 0)
                    {
                       
                        Console.Write("\t" + time + " sek kvar");                       
                    }

                    else if (time <= 0)
                    {
                        Console.Write("\tTiden är ute");
                        
                    }
                    if (vehicle.Fined == true)
                    {
                        Console.Write("\tBötfälld");
                    }

                }

                Console.WriteLine("\n\nFör att gå tillbaka till menyn tryck [M]");
                Console.WriteLine("\nFör att bötfälla tryck [B]");

                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);
                    if (key.KeyChar == 'm' || key.KeyChar == 'M')
                    {
                        exit = true;
                    }
                    else if (key.KeyChar == 'b' || key.KeyChar == 'B')
                    {
                        //Console.Clear();
                        Console.WriteLine("\nAnge regNr på det fordon du vill bötfälla: ");
                        string finedVehicle = Console.ReadLine();
                        finedVehicle = finedVehicle.ToUpper();

                        bool vehicleFound = false;
                        for (int i = 0; i < vehicles.Count; i++)
                        {
                            TimeSpan timeSpan2 = vehicles[i].EndTime - DateTime.Now;
                            int time2 = (int)timeSpan2.TotalSeconds;

                            if (finedVehicle == vehicles[i].RegNr && time2 < 0)
                            {
                                vehicleFound = true;
                                if (vehicles[i].Fined == true)
                                {
                                    Console.WriteLine("\nFordonet är redan bötfällt, kan inte bötfällas igen.");
                                }

                                else
                                {
                                    vehicles[i].Fined = true;
                                    income.FineIncome += 500;
                                    Console.WriteLine("Fordon " + vehicles[i].RegNr + " är bötfällt.");
                                }
                                break;
                            }
                        }
                        if (vehicleFound == false)
                        {
                            Console.WriteLine("Det här fordonet går inte att bötfälla.");

                        }
                        
                    }
                    Thread.Sleep(3000);
                }
                       
                Thread.Sleep(1000);
                Console.Clear();

            }
            
        }

        public static void CostumerView(ParkingLot parkingLot, List<Vehicle> vehicles, List<MC> mCs, Income income) 
        {
            bool exit2 = false;

            while (exit2 == false)
            {
                Console.WriteLine("Är du ny kund [1]?");
                Console.WriteLine("Är du befintligt kund [2]?");

                ConsoleKeyInfo key = Console.ReadKey();
                Console.Clear();
                switch (key.KeyChar)
                {
                    case '1':
                        Helpers.VehicleCheckIn(parkingLot, vehicles, mCs);
                        income.NumberOfVehicles = Helpers.AddNumberOfVehicles(income.NumberOfVehicles);
                        break;

                    case '2':

                        bool lyckad2 = false;
                        bool correct = false;
                        while (lyckad2 == false)
                        {
                            Console.WriteLine("Ange ditt registreringsnummer: ");
                            string givenRegNr = Console.ReadLine();
                            givenRegNr = givenRegNr.ToUpper();

                            for (int i = 0; i < vehicles.Count; i++)
                            {

                                if (givenRegNr == vehicles[i].RegNr)
                                {
                                    correct = true;
                                }
                                if (correct == true)
                                {                                 
                                    while (exit2 == false)
                                    {
                                        Console.Clear();
                                        
                                        TimeSpan timeSpan = vehicles[i].EndTime - DateTime.Now;
                                        int time = (int)timeSpan.TotalSeconds;
                                        Console.WriteLine("Du har plats " + (vehicles[i].ParkingSpot + 1) +(vehicles[i] is Bus ? " & " + (vehicles[i].ParkingSpot + 2) : "") + 
                                            (time > 0 ? "\nDin kvarvarande tid är: " + time : "\nDin tid är slut. Var god checka ut eller förläng din tid."));


                                        TimeSpan timeSpan2 = DateTime.Now - vehicles[i].StartingTime;
                                        int time2 = (int)timeSpan2.TotalSeconds;
                                        Console.WriteLine("\nKostnad för parkering hittills: " + Helpers.CalculatePrice(time2, vehicles[i]) + "kr (exklusive eventuella böter)");
                                      
                                        int parkingTime = vehicles[i].ParkingTime;

                                        Console.WriteLine("\n\nChecka ut [1]?");
                                        Console.WriteLine("Förlänga tiden [2]?");
                                        Console.WriteLine("Tillbaka till menyn [3]");

                                        if (Console.KeyAvailable)
                                        {
                                            var key1 = Console.ReadKey(true);
                                            switch (key1.KeyChar)
                                            {
                                                case '1':
                                                    DateTime checkOutTime = DateTime.Now;
                                                    double parkedTime = Helpers.CalculateParkedTime(checkOutTime, vehicles[i]);
                                                    vehicles[i].ParkingCost += Helpers.CalculatePrice(parkedTime, vehicles[i]);
                                                    Console.WriteLine("\nKostnaden för den parkerade tiden blev: " + vehicles[i].ParkingCost + " kr.");
                                                    income.ParkingIncome += vehicles[i].ParkingCost;

                                                    if (vehicles[i].Fined == true)
                                                    {
                                                        vehicles[i].ParkingCost += 500;
                                                        Console.WriteLine("Du betalar även 500 kr för böter.");
                                                        Console.WriteLine("\nDin totala kostnad för parkeringen blir " + vehicles[i].ParkingCost + " kr.");
                                                    }


                                                    Console.WriteLine("För att betala tryck [B]");

                                                    ConsoleKeyInfo key3 = Console.ReadKey();
                                                    Console.Clear();
                                                    switch (key3.KeyChar)
                                                    {
                                                        case 'B':
                                                        case 'b':
                                                            Console.WriteLine("Tack för din betalning!");
                                                            income.TotalIncome += vehicles[i].ParkingCost;
                                                            Helpers.CheckOut(vehicles[i], parkingLot, vehicles, mCs);
                                                            exit2 = true;
                                                            lyckad2 = true;
                                                            break;
                                                    }
                                                    break;

                                                case '2':
                                                    Console.WriteLine("Fyll i den tid du vill förlänga med i sekunder: ");
                                                    bool lyckad = false;
                                                    int extendedTime = 0;
                                                    while (lyckad == false)
                                                    {
                                                        lyckad = Int32.TryParse(Console.ReadLine(), out extendedTime);
                                                        if (!lyckad)
                                                        {
                                                            Console.WriteLine("Du har inte angett antal med siffor, ");
                                                        }
                                                    }
                                                    Helpers.CalculateExendedTime(extendedTime, vehicles[i]);
                                                    TimeSpan timeSpan3 = vehicles[i].EndTime - DateTime.Now;
                                                    int time3 = (int)timeSpan3.TotalSeconds;
                                                    Console.WriteLine("Du har plats " + (vehicles[i].ParkingSpot + 1) + "\t din nya parkeringstid är: " + time3);
                                                    double newParkingCost = Helpers.CalculatePrice(time3, vehicles[i]);
                                                    Console.WriteLine("\nDen nya kostnaden för parkeringen är: " + newParkingCost + " kr.");
                                                    //exit2 = true;
                                                    lyckad2 = true;
                                                    Thread.Sleep(3000);
                                                    break;

                                                case '3':
                                                    return;
                                                }
                                            }
                                        Thread.Sleep(1000);
                                        }

                                    }

                                }
                            if (correct == false)
                            {
                                Console.WriteLine("Du har inte angett ett registreringsnummer som finns registrerat hos oss.");
                                Console.WriteLine("För att återgå till menyn tryck: [1]?");
                                Console.WriteLine("För att försöka igen tryck: [2]?");
                                ConsoleKeyInfo key2 = Console.ReadKey();
                                Console.Clear();
                                switch (key2.KeyChar)
                                {
                                    case '1':
                                        return;
                                        break;


                                    case '2':

                                        break;

                                }
                            }


                            

                        }

                    break;
                }
               
                if (Console.KeyAvailable)
                {
                    var key5 = Console.ReadKey(true);
                    exit2 = true;

                }
                Console.WriteLine("\n\nTryck på valfri knapp för att gå tillbaka till menyn! ");

                Console.Clear();
                return;
            }

            return;

        }

        public static void TheBossView(Income income)
        {
            Console.WriteLine("Välkommen chefen!");
            
            Console.WriteLine("\nTotalt antal parkerade bilar idag: " + income.NumberOfVehicles);
            
            Console.WriteLine("\nDagens intäkter från parkeringar: " + income.ParkingIncome + "kr");

            Console.WriteLine("\nDagens intäkter från böter: " + income.FineIncome + "kr");

            Console.WriteLine("\nDagens totala intäkter: " + income.TotalIncome + "kr");

            Console.WriteLine("\n\nTryck på valfri knapp för att gå tillbaka till menyn! ");
            Console.ReadKey();

        }
    }
}
