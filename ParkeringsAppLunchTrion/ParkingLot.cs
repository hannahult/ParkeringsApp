using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkeringsAppLunchTrion
{
    public class ParkingLot
    {
        public int[] ParkingSpots { get; set; }
        public ParkingLot() 
        {
            ParkingSpots = new int[25];
            
            for (int i = 0; i < ParkingSpots.Length; i++)
            {
                ParkingSpots[i] = 0;
            }
        }

        public static void ParkVehicle(ParkingLot parkingLot, Vehicle vehicle, List<MC> mCs)
        {
            for (int i = 0; i < parkingLot.ParkingSpots.Length; i++)
            {
                if (parkingLot.ParkingSpots[i] == 1 && vehicle is MC)
                {
                    foreach (MC mc in mCs)
                    { 
                        if (mc.ParkingSpot == i)
                        {
                            vehicle.ParkingSpot = i;

                            parkingLot.ParkingSpots[i] = 2;

                            Console.WriteLine($"MC {vehicle.RegNr} parkerad på plats {i}.");

                            return;
                        }
                    }

                    break;
                }
                else if (parkingLot.ParkingSpots[i] == 0)
                {
                    if (IsSpotAvaliable(vehicle, parkingLot) == true)
                    {                  
                        if (vehicle is Car)
                        {
                            vehicle.ParkingSpot = i;
                            parkingLot.ParkingSpots[i] = 1;

                            Console.WriteLine($"Bil {vehicle.RegNr} parkerad på plats {i}.");

                        }
                        else if (vehicle is Bus)
                        {
                            vehicle.ParkingSpot = i;
                            parkingLot.ParkingSpots[i] = 1;
                            parkingLot.ParkingSpots[i+1] = 1;

                            Console.WriteLine($"Buss {vehicle.RegNr} parkerad på plats {i} & {i+1}.");
                        }
                        else if (vehicle is MC)
                        {
                            vehicle.ParkingSpot = i;
                            parkingLot.ParkingSpots[i] = 1;

                            Console.WriteLine($"MC {vehicle.RegNr} parkerad på plats {i}.");
                        }
                        return;
                    }
                }                            
            }
            Console.WriteLine("Det finns ingen ledig plats för ditt fordon!");
        }

        public static bool IsSpotAvaliable(Vehicle vehicle, ParkingLot parkingLot)
        {
            bool spotAvaliable = false;

            if (vehicle is Car || vehicle is MC)
            {
                spotAvaliable = true;
            }
            else if (vehicle is Bus)
            {
                for (int i = 0; i < parkingLot.ParkingSpots.Length - 1; i++)
                {
                    if (parkingLot.ParkingSpots[i] == 0 && parkingLot.ParkingSpots[i + 1] == 0)
                    {
                        spotAvaliable = true;
                    }
                }
            }
            
            return spotAvaliable;

        }

    }
}
