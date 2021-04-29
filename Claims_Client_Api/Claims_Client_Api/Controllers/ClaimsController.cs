using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Claims_Client_Api.Models;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Claims_Client_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClaimsController : ControllerBase
    {

        private readonly ILogger<ClaimsController> _logger;

        public ClaimsController(ILogger<ClaimsController> logger)
        {
            _logger = logger;
        }

        [Route("{date:datetime}")]
        [HttpGet]
        public IEnumerable<Member> GetClaimsByMember(string date)
        {
            Member response = new Member();
            List<Member> _getMembers = GetMembers();
            List<Claim> _getClaims = GetClaims();
            DateTime _date = DateTime.Parse(date);
           var _dateVal = _date.ToString("MM/dd/yy");

            var claimVals = _getClaims.Where(d => d.ClaimDate == DateTime.Parse(_dateVal)).ToList();
            if (claimVals.Count >0) {
                var memberVals = _getMembers.Where(m => m.MemberID == claimVals[0].MemberID).ToList();
                if (memberVals.Count > 0)
                {
                    response.MemberID = claimVals[0].MemberID;
                    response.FirstName = memberVals[0].FirstName;
                    response.LastName = memberVals[0].LastName;
                    response.EnrollmentDate = memberVals[0].EnrollmentDate;
                    response.ClaimDate = claimVals[0].ClaimDate;
                    response.ClaimAmount = claimVals[0].ClaimAmount;
                }
            }

            yield return response;
        }


        private List<Member> GetMembers()
        {
            List<Member> _m = new List<Member>
            {
                new Member {MemberID = 1123, EnrollmentDate = DateTime.Parse("09/01/2020"), FirstName = "John", LastName = "Doe"},
                new Member {MemberID = 1245, EnrollmentDate = DateTime.Parse("10/03/2020"), FirstName = "Jane", LastName = "Doe"},
            };

            return _m;
        }

        private List<Claim> GetClaims()
        {
            List<Claim> _c = new List<Claim>
            {
                new Claim { MemberID = 1123, ClaimDate = DateTime.Parse("10/06/2020"), ClaimAmount = (Decimal)1112.56 },
                    new Claim {MemberID = 1245, ClaimDate = DateTime.Parse("12/05/2020"), ClaimAmount = (Decimal)67.54}
            };

            return _c;
        }
    }
}
