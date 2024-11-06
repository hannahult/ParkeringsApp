using ParkeringsAppLunchTrion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ParkeringsAppLunchTrion
{
    public class Helpers
    {
        public static void VehicleCheckIn(ParkingLot parkingLot, List<Vehicle> vehicles, List<MC> mCs)
        {
            
            int randomVehicle = Random.Shared.Next(0, 3);
            switch (randomVehicle)
            {
                case 0:
                    Console.WriteLine("En bil rullar in på parkeringen");
                    break;
                case 1:
                    Console.WriteLine("En buss rullar in på parkeringen");
                    break;
                case 2:
                    Console.WriteLine("En MC rullar in på parkeringen");
                    break;
            }
            Console.WriteLine("Ange registreringsnummer: ");
            string regNumber = Console.ReadLine();

            Console.WriteLine("Ange färg på ditt fordon: ");
            string vehicleColor = Console.ReadLine();

            Console.WriteLine("Hur länge vill du parkera i sekunder? ");
            bool lyckad1 = Int32.TryParse(Console.ReadLine(), out int parkingTime);
            if (!lyckad1)
            {
                Console.WriteLine("Du har inte angett sekunder med siffor");
            }

            switch (randomVehicle)
            {
                case 0: //Bil
                    Console.WriteLine("Är det en elbil?");
                    Console.WriteLine("[1] ja");
                    Console.WriteLine("[2] nej");
                    ConsoleKeyInfo key = Console.ReadKey();
                    Console.Clear();
                    switch (key.KeyChar)
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

                case 1: //Buss
                    Console.WriteLine("Hur många platser är det i bussen?");
                    bool lyckad = Int32.TryParse(Console.ReadLine(), out int numberOfSeats);
                    if (!lyckad)
                    {
                        Console.WriteLine("Du har inte angett antal med siffor");
                    }
                    Bus bus1 = new Bus(regNumber, vehicleColor, numberOfSeats, parkingTime);
                    vehicles.Add(bus1);
                    ParkingLot.ParkVehicle(parkingLot, bus1, mCs);
                    break;

                case 2: //MC
                    Console.WriteLine("Vilket märke är det på motorcykeln?");
                    string mcBrand = Console.ReadLine();

                    MC mc1 = new MC(regNumber, vehicleColor, mcBrand, parkingTime);
                    vehicles.Add(mc1);
                    mCs.Add(mc1);
                    ParkingLot.ParkVehicle(parkingLot, mc1, mCs);
                    break;
            }
            Thread.Sleep(3000);
            return;

        }
    }
}
