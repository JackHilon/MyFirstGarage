using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyFirstGarage
{
    public interface IGarageController
    {
        bool InsertVehicle(Vehicle v);
        bool RemoveVehicle(Vehicle v);
    }

    // --------------------------------------------------------------

    public class GarageController : IGarageController
    {
        public GarageController(Garage garage)
        {
            Garage = garage;
        }

        // ---- #### Retrieve Person #### ----
        
        private bool SamePersons(Person p, Person q)
        {
            if (p.FirstName == q.FirstName &&
                p.LastName == q.LastName &&
                p.PersonId == q.PersonId)
                return true;
            else
                return false;
        }
        public List<Vehicle> RetrieveVehicle(string firstName, string lastName, string personId)
        {
            Person person = new Person(firstName, lastName, personId);

            var vehicles = new List<Vehicle>();

            try
            {
                // System.NullReferenceException: 'Object reference not set to an instance of an object.'
                vehicles = this.Garage.GarageArray.Where(v => SamePersons(v.Driver, person)).Select(v => v).ToList();
            }

            catch (NullReferenceException ex)
            {
                return null;
            }

            return vehicles;
        }

        public List<Vehicle> ListVehiclesAllOrType(string c)
        {
            var vehicles = new List<Vehicle>();

            try
            {
                // All vehicles
                if (c == "0")
                    // System.NullReferenceException: 'Object reference not set to an instance of an object.'
                    vehicles = this.Garage.GarageArray.Where(v => v != null).Select(v => v).ToList();
                
                // All cars
                if (c == "1")
                    // System.NullReferenceException: 'Object reference not set to an instance of an object.'
                    vehicles = this.Garage.GarageArray.Where(v => v is Car).Select(v => v).ToList();
                
                // All motorcycles
                else 
                // System.NullReferenceException: 'Object reference not set to an instance of an object.'
                vehicles = this.Garage.GarageArray.Where(v => v is MotorCycle).Select(v => v).ToList();
            }

            catch (NullReferenceException ex)
            {
                return null;
            }

            return vehicles;
        }
        // ---- #### --------------- #### ----

        //..... Same Vehicles .....
        private bool SameVehicles(Vehicle v, Vehicle w)
        {
            if (v.RegNo == w.RegNo &&
                v.Volume == w.Volume &&
                v.Driver.FirstName == w.Driver.FirstName &&
                v.Driver.LastName == w.Driver.LastName &&
                v.Driver.PersonId == w.Driver.PersonId)
                return true;
            else
                return false;
        }
        //.........................

        public bool RemoveVehicle(Vehicle v)
        {
            if (this.VehicleExists(v) == false)
                return false;
            else
            {
                var vehicleIndex = this.GetThisVehicleIndex(v);
                if (vehicleIndex == this.Garage.GarageArray.Length)
                {
                    // --> Impossible value: out of range
                    return false;
                }
                else
                {
                    this.Garage.GarageArray[vehicleIndex] = null;
                    return true;
                }
            }
        }
        private int GetThisVehicleIndex(Vehicle v)
        {
            int vehicleIndex = this.Garage.GarageArray.Length; // <-- Impossible value: out of range
            for (int i = 0; i < this.Garage.GarageArray.Length; i++)
            {
                if (SameVehicles(this.Garage.GarageArray[i], v))
                {
                    vehicleIndex = i;
                    return vehicleIndex;
                }
            }
            return vehicleIndex;
        }

        private bool VehicleExists(Vehicle v)
        {
            for (int i = 0; i < this.Garage.GarageArray.Length; i++)
            {
                if (SameVehicles(this.Garage.GarageArray[i], v))
                {
                    return true;
                }
            }
            return false;
        }

        public bool InsertVehicle(Vehicle v)
        {
            if (this.GarageIsFull() == true)
                return false;
            else
            {
                var emptIndex = this.GetFirstEmptyIndex();
                if (emptIndex == this.Garage.GarageArray.Length)
                {
                    // --> Impossible value: out of range
                    return false;
                }
                else
                {
                    this.Garage.GarageArray[emptIndex] = v;
                    return true;
                }
            }
        }

        private int GetFirstEmptyIndex()
        {
            int FirstEmptyIndex = this.Garage.GarageArray.Length;// <-- Impossible value: out of range
            for (int i = 0; i < this.Garage.GarageArray.Length; i++)
            {
                // if (this.Garage.GarageArray[i].Volume == 0)
                if (this.Garage.GarageArray[i] == null) // empty place means zero vehicle volume
                {
                    FirstEmptyIndex = i;
                    return FirstEmptyIndex;
                }
            }
            return FirstEmptyIndex;
        }

        private bool GarageIsFull()
        {
            for (int i = 0; i < this.Garage.GarageArray.Length; i++)
            {
                if (this.Garage.GarageArray[i] == null)
                    return false;
            }
            return true;
        }

        public Garage Garage { get; set; }

    }
}
