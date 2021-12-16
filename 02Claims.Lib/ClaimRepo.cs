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
            
            return false;
        }

        public bool CreateClaim()
        {
            //get user input
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
