using System;
namespace Claims_Client_Api.Models
{
    public class Member : Claim
    {
        public int MemberID { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

}
