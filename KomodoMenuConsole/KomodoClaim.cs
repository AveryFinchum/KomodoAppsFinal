using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _KomodoClaims
{
    internal class KomodoClaim
    {
        /// <summary>
        /// Requirements from contract:
        ///     ClaimID
        ///     ClaimType: Car, Home, Theft
        ///     Descripttion
        ///     ClaimAmount
        ///     DateOfIncident
        ///     DateOfClaim
        ///     IsValid: Only valid if DateOfCaim - DateOfIncident <= 30 days
        /// </summary>
        public enum ClaimType { Car = 1, Home, Theft }

        public KomodoClaim() { }
        public KomodoClaim(int id, ClaimType claimType, string description, decimal claimAmount, string ingredients)
        {
            ClaimID = id;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            Ingredients = ingredients;
        }

        //Required fields
        public int ClaimID { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public decimal ClaimAmount { get; set; }

    }
}
