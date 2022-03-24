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
        ///     Description
        ///     ClaimAmount
        ///     DateOfIncident
        ///     DateOfClaim
        ///     IsValid: Only valid if DateOfCaim - DateOfIncident <= 30 days
        /// </summary>
        public enum ClaimTypes { Car = 1, Home, Theft }

        public KomodoClaim() { }
        public KomodoClaim(int id, ClaimTypes claimType, string description, decimal claimAmount, DateTime incidentDate, DateTime dateClaimFiled, bool isValid)
        {
            ClaimID = id;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = incidentDate;
            DateOfClaim = dateClaimFiled;

            TimeSpan claimTimeSpan = new TimeSpan(0); // creeate empty timespan
            if(claimTimeSpan > TimeSpan.FromDays(0))

            try
            {
                claimTimeSpan = dateClaimFiled - incidentDate; // Checking to see if the user input 
            }
            finally { }


            if (claimTimeSpan <= TimeSpan.FromDays(30) && claimTimeSpan > TimeSpan.FromDays(0)) // If timespan was valid and if it is less than 30 days
            {
                IsValid = true; // then the claim is valid
            }
            else
            {
                IsValid = false;// otherwise the claim will not be valid
            }
        }

        //Required fields
        public int ClaimID { get; set; }
        public ClaimTypes ClaimType { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid {  get; private set; }

    }
}
