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
        public static string[] VehicleCheckIn(string[] parkingLots, List<Vehicle> vehicles)
        {
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

            int randomVehicle = Random.Shared.Next(0, 3);

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
                            for (int i = 0; i < parkingLots.Length; i++)
                            {
                                if (parkingLots[i] == null)
                                {
                                    parkingLots[i] = "Plats " + (i + 1) + "\t\t" + car1.GetType().Name + "\t" + regNumber + "\t" + vehicleColor + "\t" + "Elbil" + "\t" + "sekunder kvar";
                                    Console.WriteLine(parkingLots[i]);
                                    break;
                                }
                            }
                            break;

                        case '2':
                            Car car2 = new Car(regNumber, vehicleColor, false, parkingTime);
                            vehicles.Add(car2);
                            for (int i = 0; i < parkingLots.Length; i++)
                            {
                                if (parkingLots[i] == null)
                                {

                                    parkingLots[i] = "Plats " + (i + 1) + "\t\t" + car2.GetType().Name + "\t" + regNumber + "\t" + vehicleColor + "\t" + "Bil" + "\t" + parkingTime + " sekunder kvar";
                                    Console.WriteLine(parkingLots[i]);

                                    break;
                                }
                            }
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
                    for (int i = 0; i < parkingLots.Length; i++)
                    {
                        if (parkingLots[i] == null)
                        {
                            parkingLots[i] = "Plats " + (i + 1) + "\t\t" + bus1.GetType().Name + "\t" + regNumber + "\t" + vehicleColor + "\t" + "Antal platser: " + numberOfSeats + "\t" + parkingTime + " sekunder kvar";
                            Console.WriteLine(parkingLots[i]);
                            break;
                        }
                    }
                    break;

                case 2: //MC
                    Console.WriteLine("Vilket märke är det på motorcykeln?");
                    string mcBrand = Console.ReadLine();

                    MC mc1 = new MC(regNumber, vehicleColor, mcBrand, parkingTime);
                    vehicles.Add(mc1);
                    for (int i = 0; i < parkingLots.Length; i++)
                    {
                        if (parkingLots[i] == null)
                        {
                            parkingLots[i] = "Plats " + (i + 1) + "\t\t" + mc1.GetType().Name + "\t" + regNumber + "\t" + vehicleColor + "\t" + mcBrand + "\t" + parkingTime + " sekunder kvar";
                            Console.WriteLine(parkingLots[i]);
                            break;
                        }
                    }
                    break;
            }
            return parkingLots;

        }

        
    }
}
