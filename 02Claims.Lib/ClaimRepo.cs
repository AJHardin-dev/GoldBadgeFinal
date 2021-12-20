using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Claims.Lib
{
    public class ClaimRepo
    {
        private readonly Dictionary<int, Claim> _claims = new Dictionary<int, Claim>();

        public bool CreateClaim(Claim claim)
        {
            _claims.Add(claim.ClaimId, claim);

            if(_claims.ContainsKey(claim.ClaimId))
                return true;
            else return false;
        }

        public bool CreateClaim()
        {
            Console.WriteLine("Create a new claim\n");

            Console.WriteLine("Enter a claim ID:");
            int userClaimID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the claim type:");
            string userClaimType = Console.ReadLine();

            Console.WriteLine("Enter a claim description:");
            string userClaimDescription = Console.ReadLine();

            Console.WriteLine("Enter a claim amount:");
            decimal userClaimAmount = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Enter the date of the incident: (YYYY-MM-DD)");
            string userDateOfIncident = Console.ReadLine();

            Console.WriteLine("Enter the date of the claim: (YYYY-MM-DD)");
            string userDateOfClaim = Console.ReadLine();    

            // stopped here

            return false;
        }

        public Claim GetById(int id)
        {
            if (_claims.ContainsKey(id))
                return _claims[id];
            return null;
        }

        public Dictionary<int, Claim> GetAll()
        {
            return _claims;
        }

        public bool UpdateClaimById(int id)
        {
            return false;
        }

        public bool DeleteById(int id)
        {
            if (_claims.ContainsKey(id))
            {
                _claims.Remove(id);
                return true;
            }
            return false;
        }
    }
}
