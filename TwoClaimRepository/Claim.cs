using System;

namespace TwoClaimRespository
{
    public class Claim
    {
        public int ClaimID { get; set; }
        public string ClaimType { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public string DateOfIncident { get; set; }
        public string DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        public Claim() { }

        public Claim(int claimId, string claimType, string description, double claimAmount, string dateOfIncident,
            string dateOfClaim, bool isValid)
        {
            ClaimID = claimId;
            ClaimType = claimType;
            Description = description;
            Amount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
        }
    }

}
