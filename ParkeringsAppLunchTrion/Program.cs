using System.Security.Cryptography;
using System.Windows.Markup;



namespace ParkeringsAppLunchTrion
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            ParkingLot parkingLot = new ParkingLot();

            List<Vehicle> vehicles = new List<Vehicle>();

            List<MC> mCs = new List<MC>();

            Income income = new Income();

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
                        Person.CostumerView(parkingLot, vehicles, mCs, income);
                        break;

                    case '2':
                        Person.ParkingmanView(vehicles, income);
                        break;

                    case '3':
                        Person.TheBossView(income);
                        break;
                }

                


               


            }

        }
    }
}
