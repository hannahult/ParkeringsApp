using ParkeringsAppLunchTrion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Numerics;

namespace ParkeringsAppLunchTrion
{
    public class Helpers
    {
        public static void VehicleCheckIn(ParkingLot parkingLot, List<Vehicle> vehicles, List<MC> mCs)
        {
            //int randomVehicle = Random.Shared.Next(0, 3);
            //switch (randomVehicle)

            ConsoleKeyInfo key = Console.ReadKey();
            Console.Clear();
            switch (key.KeyChar)
            {
                case '0':
                    Console.WriteLine("En bil rullar in på parkeringen");
                    break;
                case '1':
                    Console.WriteLine("En buss rullar in på parkeringen");
                    break;
                case '2':
                    Console.WriteLine("En MC rullar in på parkeringen");
                    break;
            }

            string regNumber = "";
            while (regNumber == "")
            {
                Console.WriteLine("Ange registreringsnummer: ");
                string checkRegNumber = Console.ReadLine();
                checkRegNumber = checkRegNumber.ToUpper();
                var isValid = Regex.IsMatch(checkRegNumber, @"^[A-Z]{3}\d{3}$");
                if (isValid)
                {
                    regNumber = checkRegNumber;
                }
                else
                {
                    Console.WriteLine("Ange rätt regNummer i rätt format, ex: (ABC123)");
                }
            }

            Console.WriteLine("Ange färg på ditt fordon: ");
            string vehicleColor = Console.ReadLine();

            
            Console.WriteLine("Hur länge vill du parkera i sekunder? ");

            bool lyckad1 = false;
            int parkingTime;
            while (lyckad1 == false)
            {
                lyckad1 = Int32.TryParse(Console.ReadLine(), out parkingTime);
                if (!lyckad1)
                {
                    Console.WriteLine("Du har inte angett sekunder med siffor! ");
                }
            }

            //switch (randomVehicle)

            switch (key.KeyChar)
            {
                case '0': //Bil
                    Console.WriteLine("Är det en elbil?");
                    Console.WriteLine("[1] ja");
                    Console.WriteLine("[2] nej");
                    ConsoleKeyInfo key1 = Console.ReadKey();
                    Console.Clear();
                    switch (key1.KeyChar)
                    {
                        case '1':
                            Car car1 = new Car(regNumber, vehicleColor, true, parkingTime);
                            vehicles.Add(car1);
                            ParkingLot.ParkVehicle(parkingLot, car1, mCs);
                            break;

                        case '2':
                            Car car2 = new Car(regNumber, vehicleColor, false, parkingTime);
                            vehicles.Add(car2);
                            ParkingLot.ParkVehicle(parkingLot, car2, mCs);
                            break;
                    }
                    break;

                case '1': //Buss
                    Console.WriteLine("Hur många platser är det i bussen?");
                    bool lyckad = false;
                    int numberOfSeats;
                    while (lyckad == false)
                    {
                        lyckad = Int32.TryParse(Console.ReadLine(), out numberOfSeats);
                        if (!lyckad)
                        {
                            Console.WriteLine("Du har inte angett antal med siffor, ");
                        }
                    }
                    Bus bus1 = new Bus(regNumber, vehicleColor, numberOfSeats, parkingTime);
                    vehicles.Add(bus1);
                    ParkingLot.ParkVehicle(parkingLot, bus1, mCs);
                    break;

                case '2': //MC
                    Console.WriteLine("Vilket märke är det på motorcykeln?");
                    string mcBrand = Console.ReadLine();

                    MC mc1 = new MC(regNumber, vehicleColor, mcBrand, parkingTime);
                    vehicles.Add(mc1);
                    mCs.Add(mc1);
                    ParkingLot.ParkVehicle(parkingLot, mc1, mCs);
                    break;
            }
            Console.WriteLine("\n\nTryck på valfri knapp för att gå tillbaka till menyn! ");
            Console.ReadKey();
            return;

        }

        public static void AddTestVehicles (ParkingLot parkingLot, List<Vehicle> vehicles, List<MC> mCs)
        {
            Car testCar = new Car("abc123", "Blå", true, 250);
            vehicles.Add(testCar);
            testCar.ParkingSpot = 0;
            parkingLot.ParkingSpots[0] = 2;

            MC testMC = new MC("def456", "Grå", "Yamaha", 200);
            vehicles.Add(testMC);
            testMC.ParkingSpot = 1;
            parkingLot.ParkingSpots[1] = 1;
            mCs.Add(testMC);
            

            Bus testBus = new Bus("ghi789", "Röd", 8, 230);
            vehicles.Add(testBus);
            testBus.ParkingSpot = 2;
            parkingLot.ParkingSpots[2] = 2;
            parkingLot.ParkingSpots[3] = 2;

        }


    }
}
