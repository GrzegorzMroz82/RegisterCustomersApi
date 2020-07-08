using GameTek.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameTekRegWebApp.Models
{
    public class RedbetCustomer : CustomerData, IEquatable<RedbetCustomer>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string FavoriteFootballTeam { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            RedbetCustomer r = (RedbetCustomer)obj;
            return this.Equals(r);
        }

        public bool Equals(RedbetCustomer other)
        {
            return FirstName.Equals(other.FirstName) && LastName.Equals(other.LastName) && Address.Equals(other.Address);
        }

        public override int GetHashCode()
        {
            return (FirstName + LastName).GetHashCode();
        }

        public override string ToString()
        {
            return "RedbetCustomer: " + FirstName + LastName;
        }

        public override bool Validate()
        {
            return !string.IsNullOrEmpty(FirstName) &&
                !string.IsNullOrEmpty(LastName) &&
                !string.IsNullOrEmpty(Address) &&
                !string.IsNullOrEmpty(FavoriteFootballTeam);
        }
    }
}
