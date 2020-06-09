using System;
using System.Collections.Generic;
using System.Linq;

namespace MyFirstGarage
{
    class Program
    {
        static void Main(string[] args)
        {
            // ============== need to be improved !!!! ============================================
            // == Search about vehicle / person == enter person and get vehicle (and vice versa) ==
            // == in the third part ===============================================================

            //FirstPart();
            //SecondPart();


            // ====== THIRD PART ======

            var myCont = GarageControllerCreate();


            while (true)
            {
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine("(0) ................ Park/Unpark your vehicle");
                Console.WriteLine("(1) ................ Search about a vehicle using driver info");
                Console.WriteLine("(2) ................ List all vehicles or according to its type");
                Console.WriteLine("(any other key) .... Exit");

                var eFlag = Console.ReadLine();
                Console.WriteLine(" ");
                
                switch (eFlag)
                {
                    case "0":
                        // ---- Enter a person ----
                        var prsn = EnterPersonIdentity();

                        // ---- Enter your car/motorcycle info
                        var myVehicle = EnterVehicleInfo(prsn);

                        // ------ (Park / Unpark) your vehicle ------
                        ParkUnpark(myCont, myVehicle);
                        continue;
                    
                    case "1":
                        // ------ Search about a vehicle using driver info ------
                        SearchVehicleUsingDriverInfo(myCont);
                        continue;

                    case "2":
                        // ----- See all Cars in the garage -----
                        ListPart(myCont);
                        continue;

                    default:
                        break;
                }
                break;

            }// end while

        } // --- end of Main() ---

        private static void SearchVehicleUsingDriverInfo(GarageController myCont)
        {
            Console.WriteLine(" ");
            Console.WriteLine("----{ Search using Driver INFO }----");
            Console.Write("Enter Driver's first name: ");
            var fName = Console.ReadLine();
            Console.Write("Enter Driver's last name.: ");
            var lName = Console.ReadLine();
            Console.Write("Enter Driver's Id........: ");
            var idDriver = Console.ReadLine();
            Console.WriteLine(" ");

            var vehicles = myCont.RetrieveVehicle(fName, lName, idDriver);

            if (vehicles == null)
                Console.WriteLine("There is no such driver in this garage !!!!");

            if (vehicles != null)
            {
                ShowVehicleInfo(vehicles);
            }
            Console.WriteLine("----{ End of search using Driver INFO }----");
            Console.WriteLine(" ");
        }

        private static void ListPart(GarageController myCont)
        {
            // (0)... All vehicles  (1)... Only Cars  (any other key)... MotorCycles
            Console.WriteLine(" ");
            Console.WriteLine("=========== List Vehicles ===========");
            Console.WriteLine("(0) ................. All vehicles");
            Console.WriteLine("(1) ................. All cars");
            Console.WriteLine("(any other key) ..... All motorcycles");
            var VehFlag = Console.ReadLine();

            Console.WriteLine(" ");
            SeeVehiclesAllOrType(myCont, VehFlag);
            Console.WriteLine(" ");
        }

        private static void SeeVehiclesAllOrType(GarageController myCont, string flag)
        {
            Console.WriteLine(" ");
            Console.WriteLine("..... List of required vehicles .....");
            ShowVehicleInfo(myCont.ListVehiclesAllOrType(flag));
            Console.WriteLine(".................................");
            Console.WriteLine(" ");
        }

        private static void ShowVehicleInfo(List<Vehicle> vehicles)
        {
            if (vehicles.Count == 0)
                Console.WriteLine("There is no such vehicle in the garage !!!!");
            else
            {
                foreach (var veh in vehicles)
                {
                    Console.WriteLine($"Vehicle's register number: {veh.RegNo}");
                    Console.WriteLine($"Vehicle's volume.........: {veh.Volume}");
                    Console.WriteLine($"Vehicle's type...........: {veh.GetType().Name}");
                    if (veh is Car)
                    {
                        Car c = (Car)veh;
                        Console.WriteLine($"Car's chassis number..: {c.ChassisNumber}");
                        Console.WriteLine($"Car's number of wheels: {c.NumberOfWheels}");
                    }
                    else if (veh is Car)
                    {
                        MotorCycle c = (MotorCycle)veh;
                        Console.WriteLine($"Motorcycle's number of seats: {c.NumberOfSeats}");
                    }
                    Console.WriteLine($"------------------------------------------");
                }
            }
        }

        private static void ParkUnpark(GarageController myCont, Vehicle myVehicle)
        {
            Console.WriteLine(" ");
            Console.WriteLine("(1) ............... Park your vehicle.");
            Console.WriteLine("any other key ..... Unpark your vehicle.");
            var parkChose = Console.ReadLine();
            if (parkChose == "1")
            {
                if (myCont.InsertVehicle(myVehicle))
                    Console.WriteLine("Park successful.");
                else
                    Console.WriteLine("Park failed!!!");
            }
            else
            {
                if (myCont.RemoveVehicle(myVehicle))
                    Console.WriteLine("Unpark successful.");
                else
                    Console.WriteLine("Unpark failed!!!");
            }
            Console.WriteLine("............................................");
        }

        private static Person EnterPersonIdentity()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Enter a person");
            Console.Write("Person's first name: ");
            var fN = Console.ReadLine();

            Console.Write("Person's last name.: ");
            var lN = Console.ReadLine();

            Console.Write("Person's Id........: ");
            var prsnId = Console.ReadLine();

            var prsn = new Person(fN, lN, prsnId);
            return prsn;
        }

        private static GarageController GarageControllerCreate()
        {
            Console.WriteLine(" ");
            Console.WriteLine("----- Welcome to First Garage Program -----");
            Console.WriteLine("---------------- Third Part ---------------");
            Console.Write("Enter Garage capacity: ");

            var capStr = Console.ReadLine();
            var cap = Str2IntConverter(capStr);

            var myGarage = GarageInitialize(cap);

            var myCont = ControllerInitialize(myGarage);
            return myCont;
        }

        private static Vehicle EnterVehicleInfo(Person pr)
        {
            Console.WriteLine(" ");
            Console.WriteLine("(1) .................... Chose car.");
            Console.WriteLine("any other key .......... Chose motorcycle.");
            var choseCar = Console.ReadLine();
            Console.WriteLine(" ");

            Vehicle myVehicle;
            if (choseCar == "1")
            {
                // Car chose
                myVehicle = EnterCar(pr);
            }
            else
            {
                // Motorcycle chose
                myVehicle = EnterMotorCycle(pr);
            }
            return myVehicle;
        }

        private static Car EnterCar(Person p)
        {
            Console.Write("Car's register number.: ");
            var rN = Console.ReadLine();

            Console.Write("Car's volume..........: ");
            var vNStr = Console.ReadLine();
            var vN = Str2IntConverter(vNStr);

            Console.Write("Car's chassis number..: ");
            var cN = Console.ReadLine();

            Console.Write("Car's number of wheels: ");
            var wNStr = Console.ReadLine();
            var wN = Str2IntConverter(wNStr);

            Console.WriteLine(" ");

            var c = new Car(p, rN, vN, cN, wN);
            return c;
        }

        private static MotorCycle EnterMotorCycle(Person p)
        {
            Console.Write("Motorcycle's register number: ");
            var rN = Console.ReadLine();

            Console.Write("Motorcycle's volume.........: ");
            var vNStr = Console.ReadLine();
            var vN = Str2IntConverter(vNStr);

            Console.Write("Motorcycle's number of seats: ");
            var seatsStr = Console.ReadLine();
            var seats = Str2IntConverter(seatsStr);

            Console.WriteLine(" ");

            var m = new MotorCycle(p, rN, vN, seats);
            return m;
        }
        private static void SecondPart()
        {
            Console.WriteLine(" ");
            Console.WriteLine("----- Welcome to First Garage Program -----");
            Console.WriteLine("---------------- Second Part ---------------");
            Console.WriteLine("Garage capacity = 1 ");

            var myGarage = GarageInitialize(1);

            var myCont = ControllerInitialize(myGarage);

            var myCar = CarInitialize();

            if (myCont.InsertVehicle(myCar))
            {
                Console.WriteLine("Park is successful. ");
            }
            else
                Console.WriteLine("Park is failed!!! ");

            // .... create motorcycle and try to park it
            var myMotorCycle = MotorCycleInitialize();

            if (myCont.InsertVehicle(myMotorCycle))
            {
                Console.WriteLine("Park is successful. ");
            }
            else
                Console.WriteLine("Park is failed!!! ");

            // .... Unpark the car
            if (myCont.RemoveVehicle(myCar))
            {
                Console.WriteLine("Unpark is successful. ");
            }
            else
                Console.WriteLine("Unpark is failed!!! ");

            // ---- try to unpark the motorcycle myMotorCycle
            if (myCont.RemoveVehicle(myMotorCycle))
            {
                Console.WriteLine("Unpark is successful. ");
            }
            else
                Console.WriteLine("Unpark is failed!!! ");
        }

        private static void FirstPart()
        {
            Console.WriteLine(" ");
            Console.WriteLine("----- Welcome to First Garage Program -----");
            Console.WriteLine("---------------- First Part ---------------");
            Console.Write("Enter Garage capacity: ");

            var capStr = Console.ReadLine();
            var cap = Str2IntConverter(capStr);

            var myGarage = GarageInitialize(cap);

            var myCont = ControllerInitialize(myGarage);

            var myCar = CarInitialize();

            if (myCont.InsertVehicle(myCar))
            {
                Console.WriteLine("Park is successful. ");
            }
            else
                Console.WriteLine("Park is failed!!! ");

            if (myCont.RemoveVehicle(myCar))
            {
                Console.WriteLine("Unpark is successful. ");
            }
            else
                Console.WriteLine("Unpark is failed!!! ");
        }
        private static Garage GarageInitialize(int a)
        {
            var g = new Garage(a);
            return g;
        }

        private static GarageController ControllerInitialize(Garage g)
        {
            var c = new GarageController(g); //* 
            return c;
        }
        
        private static MotorCycle MotorCycleInitialize()
        {
            var p = PersonInitialize();
            var m = new MotorCycle(p, "A1234", 1800, 2);
            return m;
        }

        private static Car CarInitialize()
        {
            var p = PersonInitialize();
            var c = new Car(p, "A1234", 1800, "Chassis1234", 4);
            return c;
        }

        private static Person PersonInitialize()
        {
            var p = new Person("Tom", "Jerry", "1970");
            return p;
        }


        private static int Str2IntConverter(string myString)
        {
            int num = 0;
            try
            {
                num = int.Parse(myString);
            }
            catch
            {
                Console.Write("Enter a valid value: ");
                myString = Console.ReadLine();
                num = Str2IntConverter(myString);
            }
            return num;
        }
    }
}
