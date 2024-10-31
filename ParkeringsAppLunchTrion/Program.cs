using System.Windows.Markup;

namespace ParkeringsAppLunchTrion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ange registreringsnummer: ");
            string regNumber = Console.ReadLine();

            Console.WriteLine("Ange färg på ditt fordon: ");
            string vehicleColor = Console.ReadLine();

            int randomVehicle = Random.Shared.Next(0, 3);

            switch(randomVehicle)
            {
                case 0: //Bil
                    Console.WriteLine("Är det en elbil?");
                    Console.WriteLine("[1] ja");
                    Console.WriteLine("[2] nej");
                    ConsoleKeyInfo key = Console.ReadKey();
                    switch (key.KeyChar)
                    {
                        case '1':
                            new Car(regNumber, vehicleColor, true);
                            break;

                        case '2':
                            new Car(regNumber, vehicleColor, false);
                            break;
                        
                    }
                    
                    break;

                case 1: //Buss
                    Console.WriteLine("Hur många platser är det i bussen?");
                    Int32.TryParse(Console.ReadLine(), out int numberOfSeats);

                    new Bus(regNumber, vehicleColor, numberOfSeats);
                    break;

                case 2: //MC
                    Console.WriteLine("Vilket märke är det på motorcykeln?");
                    string mcBrand = Console.ReadLine();

                    new MC(regNumber, vehicleColor, mcBrand);
                    break;
            }

            


        }
    }
}
