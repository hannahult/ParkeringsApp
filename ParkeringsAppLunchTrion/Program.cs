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
            


            while (true)
            {

                Person.ParkingmanView(vehicles);



                Person.CostumerView(parkingLot, vehicles, mCs);





            }

        }
    }
}
