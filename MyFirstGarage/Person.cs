using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstGarage
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private string personId;

        public Person(string f, string l, string p)
        {
            this.firstName = f;
            this.lastName = l;
            this.personId = p;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
        }
        public string LastName
        {
            get
            {
                return this.lastName;
            }
        }
        public string PersonId
        {
            get
            {
                return this.personId;
            }
        }

        public string GetFullName()
        {
            return this.FirstName + " " + this.LastName;
        }

    }
}
