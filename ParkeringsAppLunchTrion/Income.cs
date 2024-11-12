using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkeringsAppLunchTrion
{
    public class Income
    { 
        public double ParkingIncome{ get; set; }
        public double FineIncome{ get; set; }
        public double TotalIncome { get; set; }
        public int NumberOfVehicles { get; set; }

        public Income() 
        {
            ParkingIncome = 0;
            FineIncome = 0;
            TotalIncome = 0;
            NumberOfVehicles = 3;
        }

    }
}
