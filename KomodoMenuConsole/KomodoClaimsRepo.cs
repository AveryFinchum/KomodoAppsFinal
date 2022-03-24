using _KomodoClaims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoMenuConsole
{
    internal class KomodoClaimsRepo
    {
        protected List<KomodoClaim> _KomodoClaims = new List<KomodoClaim>();

        //Repository actions:
        //Create
        public bool AddItemToClaims(KomodoClaim item)
        {
            int startingCount = _KomodoClaims.Count();
            _KomodoClaims.Add(item);
            bool wasAdded = (_KomodoClaims.Count() > startingCount);
            return wasAdded;
        }

        //Read (all that match ID)
        public List<KomodoClaim> GetKomodoClaim(int id)
        {
            List<KomodoClaim> ClaimByNumber = new List<KomodoClaim>();
            foreach (KomodoClaim claim in _KomodoClaims)
            {
                if (claim.ClaimID == id)
                {
                    ClaimByNumber.Add(claim);
                }
            }
            return ClaimByNumber.ToList(); // list is needed in case this returns two Claims with the same number
        }

        //Read one
        public KomodoClaim GetFirstKomodoClaim(int id)
        {
            foreach (KomodoClaim claim in _KomodoClaims)
            {
                if (claim.ClaimID == id)
                {
                    return claim; // return very first claim found that matches number
                }
            }
            return new KomodoClaim();
        }

        //Read (all by order number)
        public List<KomodoClaim> GetKomodoClaims()
        {
            List<KomodoClaim> ClaimsByNumber = new List<KomodoClaim>();
            foreach (KomodoClaim item in _KomodoClaims)
            {
                ClaimsByNumber.Add(item);
            }
            // LINQ order by meal number
            return ClaimsByNumber.OrderBy(c => c.ClaimID).ToList();
        }
        private void UpdateContent()
        {
            Console.Clear();
            Console.Write("Please enter the ID of the Claim you wish to update: ");
            KomodoClaim oldClaim = GetFirstKomodoClaim(int.Parse(Console.ReadLine()));
            if (oldClaim != null)
            {
                // Claim Type
                Console.Write("Please enter the Claim's type: \n1) Car \n2) Home \n3) Theft \n");
                string claimstype = Console.ReadLine();
                if (claimstype != "")
                {
                    oldClaim.ClaimType = (KomodoClaim.ClaimTypes)int.Parse(claimstype);
                }

                // Description
                Console.Write("Please enter a description: ");
                string descInput = Console.ReadLine();
                if (descInput != "")
                {
                    oldClaim.Description = descInput;
                }

                // Amount
                Console.Write("Please enter the amount of the claim: ");
                string amount = Console.ReadLine();
                if (amount != "")
                {
                    oldClaim.ClaimAmount = decimal.Parse(amount);
                }

                // Date of Incident
                Console.Write("Please enter the Date of the Incident: ");
                string date = Console.ReadLine();
                if (date != "")
                {
                    oldClaim.DateOfIncident = Convert.ToDateTime(date);
                }

                // Date Claim was Made
                Console.Write("Please enter the Date the claim was made: ");
                date = Console.ReadLine();
                if (date != "")
                {
                    oldClaim.DateOfClaim = Convert.ToDateTime(date);
                }
            }
            else
            {
                Console.WriteLine("No Claim by that ID was found");
            }

        }

        // Delete
        public bool DeleteExistingKomodoClaim(KomodoClaim existingClaim)
        {
            bool deleteResult = _KomodoClaims.Remove(existingClaim);
            return deleteResult;
        }

    }
}
