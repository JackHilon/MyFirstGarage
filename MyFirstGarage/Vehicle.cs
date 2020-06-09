using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstGarage
{
    public abstract class Vehicle
    {
        private Person driver;
        private string regNo;
        private int volume;

        public Vehicle(Person driver, string regNo, int volume)
        {
            this.driver = driver;
            this.regNo = regNo;
            this.volume = volume;
        }

        public Person Driver
        {
            get
            {
                return this.driver;
            }
        }
        public string RegNo
        {
            get
            {
                return this.regNo;
            }
        }
        public int Volume
        {
            get
            {
                return this.volume;
            }
        }
    } // -----end of: abstract class Vehicle -----
      // -------------------------------------------------------------------------------
    public class Car : Vehicle
    {
        private string chassisNumber;
        private int numberOfWheels;

        public Car(Person driver, string regNo, int volume, string chassisNumber, int numberOfWheels) : base(driver, regNo, volume)
        {
            this.chassisNumber = chassisNumber;
            this.numberOfWheels = numberOfWheels;
        }

        public string ChassisNumber
        {
            get
            {
                return this.chassisNumber;
            }
        }
        public int NumberOfWheels
        {
            get
            {
                return this.numberOfWheels;
            }
        }
    } // -----end of: class Car -----
      // -------------------------------------------------------------------------------
    public class MotorCycle : Vehicle
    {
        private int numberOfSeats;

        public MotorCycle(Person driver, string regNo, int volume, int numberOfSeats) : base(driver, regNo, volume)
        {
            this.numberOfSeats = numberOfSeats;
        }
        public int NumberOfSeats
        {
            get
            {
                return this.numberOfSeats;
            }
        }
    }// -----end of: class MotorCycle -----

}
