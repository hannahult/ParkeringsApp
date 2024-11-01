using System.Windows.Markup;

namespace ParkeringsAppLunchTrion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] parkingLots = new string[25];
            List<Vehicle> vehicles = new List<Vehicle>();

            parkingLots = Helpers.VehicleCheckIn(parkingLots, vehicles);


            while (true)
            {
                for (int i = 0; i < parkingLots.Length; i++)
                {
                    Console.WriteLine(parkingLots[i]);
                }

                foreach (Vehicle vehicle in vehicles)
                {
                    if (vehicle.ParkingTime > 0)
                    {
                        vehicle.ParkingTime--;
                    }

                }
                Thread.Sleep(1000);
                
            }

        }
    }
}
