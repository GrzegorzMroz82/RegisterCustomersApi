//using GameTek.Application;
using GameTek.Model;
using System;

namespace GameTekRegWebApp.Models
{
    public class MrGreenCustomer : CustomerData, IEquatable<MrGreenCustomer>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PersonalNumber { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            MrGreenCustomer r = (MrGreenCustomer)obj;
            return this.Equals(r);
        }

        public bool Equals(MrGreenCustomer other)
        {
            return PersonalNumber.Equals(other.PersonalNumber);
        }

        public override int GetHashCode()
        {
            return PersonalNumber.GetHashCode();
        }

        public override string ToString()
        {
            return "MrGreenCustomer nr:" + this.PersonalNumber;
        }

        public override bool Validate()
        {
            return !string.IsNullOrEmpty(FirstName) &&
                !string.IsNullOrEmpty(LastName) &&
                !string.IsNullOrEmpty(Address) &&
                !string.IsNullOrEmpty(PersonalNumber);
        }
    }
}