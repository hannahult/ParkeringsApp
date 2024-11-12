using System.Security.Cryptography;
using System.Windows.Markup;

namespace ParkeringsAppLunchTrion
{

    internal class Program
    {
        static void Main(string[] args)
        {
            ParkingLot parkingLot = new ParkingLot();

            List<Vehicle> vehicles = new List<Vehicle>();

            List<MC> mCs = new List<MC>();

            int numberOfVehicles = 3;

            //parkingLots = 
            

            Helpers.AddTestVehicles(parkingLot, vehicles, mCs);
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Välkommen till parkeringshuset! ");
                Console.WriteLine("[1] Kund");
                Console.WriteLine("[2] Parkeringsvakt");
                Console.WriteLine("[3] Chef");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.Clear();
                switch (key.KeyChar)
                {
                    case '1':
                        numberOfVehicles = Person.CostumerView(parkingLot, vehicles, mCs, numberOfVehicles);
                        break;

                    case '2':
                        Person.ParkingmanView(vehicles);
                        break;

                    case '3':
                        Person.TheBossView(numberOfVehicles);
                        break;
                }

                


               


            }

        }
    }
}
