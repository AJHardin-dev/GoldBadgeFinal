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

        public bool CreateClaim(int claimId, string claimType, string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            if (!_claims.ContainsKey(claimId))
            {
                _claims.Add(claimId, new Claim(claimId, claimType, description, claimAmount, dateOfIncident, dateOfClaim));
                return true;
            }
            else return false;
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

        public bool UpdateClaim(Claim claim)
        {
            if (claim != null)
            {
                if (_claims.ContainsKey(claim.ClaimId))
                {
                    _claims[claim.ClaimId] = claim;
                    return true;
                }
            }
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
