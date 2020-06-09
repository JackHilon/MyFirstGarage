using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstGarage
{
    public class Garage
    {
        private int maxCapacity;

        public Garage(int max)
        {
            this.maxCapacity = max;
            this.GarageArray = new Vehicle[max];
        }
        public int MaxCapacity
        {
            get
            {
                return this.maxCapacity;
            }
        }
        public Vehicle[] GarageArray { get; set; }
    }
}
