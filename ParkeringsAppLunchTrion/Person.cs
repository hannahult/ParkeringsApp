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
                    Console.Write("\nPlats " + (vehicle.ParkingSpot + 1) + "\t" + vehicle.GetType().Name + "\t" + vehicle.RegNr + "\t" + vehicle.Color + "\t");

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
                Thread.Sleep(1000);
                Console.Clear();

                //Komma ut från loopen
            }
            
        }

        public static void CostumerView(ParkingLot parkingLot, List<Vehicle> vehicles, List<MC> mCs) 
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
                    Console.WriteLine("Ange ditt registreringsnummer: ");
                    string givenRegNr = Console.ReadLine();

                    foreach (Vehicle vehicle in vehicles)
                    {
                        if (givenRegNr == vehicle.RegNr)
                        {
                            Console.WriteLine("Du har plats " + vehicle.ParkingSpot + "\t din kvarvarande tid är: " + vehicle.ParkingTime);
                            //tiden går inte neråt
                        }
                    }
                    
                    break;
            }


            
        }

        public static void TheBossView()
        {

        }
    }
}
