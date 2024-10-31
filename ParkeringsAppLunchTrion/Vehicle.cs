using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkeringsAppLunchTrion
{
    public class Vehicle
    {
        public string RegNr { get; set; }

        public string Color { get; set; }   

        public Vehicle(string regNr, string color)
        {
            RegNr = regNr;
            Color = color;
        }
    }

    public class Car : Vehicle
    {
        public bool Electric { get; set; }

        public Car(string regNr, string color, bool electric) : base(regNr, color)
        {
            Electric = electric;
        }
    }

    public class Bus : Vehicle
    {
        public int NrSeats { get; set; }

        public Bus(string regNr, string color, int nrSeats) : base (regNr, color)
        {
            NrSeats = nrSeats;
        }
    }

    public class MC : Vehicle
    {
        public string Brand { get; set; }

        public MC(string regNr, string color, string brand) : base(regNr, color)
        {
            Brand = brand;
        }

    }


}
