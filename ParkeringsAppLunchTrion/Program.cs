using System.Security.Cryptography;
using System.Windows.Markup;

namespace ParkeringsAppLunchTrion
{

    //Personklass - komma ut från whileloop
    //Personklass - tiden ska ticka ner universalt

    internal class Program
    {
        static void Main(string[] args)
        {
            //string[] parkingLots = new string[25];

            ParkingLot parkingLot = new ParkingLot();

            List<Vehicle> vehicles = new List<Vehicle>();

            List<MC> mCs = new List<MC>();

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
                        Person.CostumerView(parkingLot, vehicles, mCs);
                        break;

                    case '2':
                        Person.ParkingmanView(vehicles);
                        break;

                    case '3':

                        break;
                }

                


               


            }

        }
    }
}
