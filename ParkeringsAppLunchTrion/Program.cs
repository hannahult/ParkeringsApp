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
            


            while (true)
            {

                Person.CostumerView(parkingLot, vehicles, mCs);


                Person.ParkingmanView(vehicles);


            }

        }
    }
}
