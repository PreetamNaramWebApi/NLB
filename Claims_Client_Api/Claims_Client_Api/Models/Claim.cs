using System;
namespace Claims_Client_Api.Models
{
    public class Claim
    {
        public int MemberID { get; set; }
        public DateTime ClaimDate { get; set; }
        public Decimal ClaimAmount { get; set; }
    }
}
