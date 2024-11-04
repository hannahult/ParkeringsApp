using System.Windows.Markup;

namespace ParkeringsAppLunchTrion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string[] parkingLots = new string[25];

            ParkingLot parkingLot = new ParkingLot();

            List<Vehicle> vehicles = new List<Vehicle>();

            List<MC> mCs = new List<MC>();

            //parkingLots = 
            Helpers.VehicleCheckIn(parkingLot, vehicles, mCs);


            while (true)
            {
                

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
