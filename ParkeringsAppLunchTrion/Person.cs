using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ParkeringsAppLunchTrion
{
    public class Person
    {
        public static void ParkingmanView(List<Vehicle> vehicles)
        {
            bool exit = false;

            while (exit == false)
            {
                foreach (Vehicle vehicle in vehicles)
                {
                    if (vehicle.ParkingTime == 0)
                    {
                        Console.WriteLine("Tiden är ute för fordon " + vehicle.RegNr + " på plats " + (vehicle.ParkingSpot + 1));
                    }

                }

                foreach (Vehicle vehicle in vehicles)
                {

                    Console.Write("\nPlats " + (vehicle.ParkingSpot + 1) + (vehicle is Bus ? " & " + (vehicle.ParkingSpot + 2) : "") + "\t" + vehicle.GetType().Name + "\t" + vehicle.RegNr + "\t" + vehicle.Color + "\t");


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


                    if (vehicle.ParkingTime > 0)
                    {
                        Console.Write("\t" + vehicle.ParkingTime + " sek kvar");
                        vehicle.ParkingTime--;
                    }

                    else if (vehicle.ParkingTime == 0)
                    {
                        Console.Write("\tTiden är ute");
                    }

                }
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);
                    exit = true;

                }
                Console.WriteLine("\n\nTryck på valfri knapp för att gå tillbaka till menyn! ");
               
                Thread.Sleep(1000);
                Console.Clear();

            }
            
        }

        public static void CostumerView(ParkingLot parkingLot, List<Vehicle> vehicles, List<MC> mCs) 
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
                        break;

                    case '2':

                        bool lyckad2 = false;
                        bool correct = false;
                        while (lyckad2 == false)
                        {
                            Console.WriteLine("Ange ditt registreringsnummer: ");
                            string givenRegNr = Console.ReadLine();
                            givenRegNr = givenRegNr.ToUpper();

                            foreach (Vehicle vehicle in vehicles)
                            {

                                if (givenRegNr == vehicle.RegNr)
                                {
                                    correct = true;
                                }
                                if (correct == true)
                                {
                                    Console.WriteLine("Du har plats " + (vehicle.ParkingSpot + 1) + "\t din kvarvarande tid är: " + vehicle.ParkingTime);
                                    double parkingCost = Helpers.CalculatePrice(vehicle.ParkingTime);
                                    Console.WriteLine("Kostnaden för parkeringen blir: " + parkingCost + " kr.");
                                    int parkingTime = vehicle.ParkingTime;
                                    int startTime = vehicle.StartTime;

                                    Console.WriteLine("Checka ut [1]?");
                                    Console.WriteLine("Förlänga tiden [2]?");

                                    ConsoleKeyInfo key1 = Console.ReadKey();
                                    Console.Clear();
                                    switch (key1.KeyChar)
                                    {
                                        case '1':
                                            double parkedTime = Helpers.CheckOut(parkingTime, startTime);
                                            double earlyParkingCost = Helpers.CalculatePrice(parkedTime);
                                            Console.WriteLine("Den nya kostnaden vid tidigarelagd utcheckning blev: " + earlyParkingCost + " kr.");
                                            Console.WriteLine("För att betala tryck [B]");

                                            ConsoleKeyInfo key3 = Console.ReadKey();
                                            Console.Clear();
                                            switch (key3.KeyChar)
                                            {
                                                case 'B':
                                                case 'b':
                                                    Console.WriteLine("Tack för din betalning!");
                                                    //KOMMA UR WHILELOOPEN, vill tillbaka till startmeny
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
                                            vehicle.ParkingTime = Helpers.ExtendTime(parkingTime, extendedTime);
                                            Console.WriteLine("Du har plats " + (vehicle.ParkingSpot + 1) + "\t din nya parkeringstid är: " + vehicle.ParkingTime);
                                            double newParkingCost = Helpers.CalculatePrice(vehicle.ParkingTime);
                                            Console.WriteLine("Den nya kostnaden för parkeringen är: " + newParkingCost + " kr.");
                                            break;


                                    }
                                }

                            }
                            if (correct == false)
                            {
                                Console.WriteLine("Du har inte angett ett registreringsnummer som finns registrerat hos oss.");
                            }

                            Console.WriteLine("För att återgå till menyn tryck: [1]?");
                            Console.WriteLine("För att försöka igen tryck: [2]?");

                            ConsoleKeyInfo key2 = Console.ReadKey();
                            Console.Clear();
                            switch (key2.KeyChar)
                            {
                                case '1':
                                    lyckad2 = true;
                                    break;

                                case '2':

                                    break;

                            }

                        }

                    break;
                }


                //BRYTA UT FRÅN WHILELOOPEN, startmenyn
                if (Console.KeyAvailable)
                {
                    var key5 = Console.ReadKey(true);
                    exit2 = true;

                }
                Console.WriteLine("\n\nTryck på valfri knapp för att gå tillbaka till menyn! ");

                //Thread.Sleep(1000);
                Console.Clear();

            }


        }

        public static void TheBossView()
        {

        }
    }
}
