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
                    Console.Write("\nPlats " + (vehicle.ParkingSpot+1) + "\t" + vehicle.GetType().Name + "\t" + vehicle.RegNr + "\t" + vehicle.Color + "\t");

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

                    Console.Write("\t" + vehicle.ParkingTime + " sek kvar");

                    if (vehicle.ParkingTime > 0)
                    {
                        vehicle.ParkingTime--;
                    }

                }
                Thread.Sleep(1000);
                Console.Clear();
                
            }

        }
    }
}
