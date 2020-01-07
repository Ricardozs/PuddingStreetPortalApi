using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalApi.Requests
{
    public class CandidateRequest
    {
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string CurrentLocation { get; set; }
        public string Availability { get; set; }
        public string OverralExperience { get; set; }
        public string ITExperience { get; set; }
        public string HighestEducation { get; set; }
        public string LegalStatus { get; set; }
        public DateTime WorkPermitExpiration { get; set; }
        public string Notes { get; set; }
        public string Recruiter { get; set; }
        public string Resume { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string Job { get; set; }
        public int Skill1 { get; set; }
        public int Skill2 { get; set; }
        public int Skill3 { get; set; }
        public int Skill4 { get; set; }
        public int Skill5 { get; set; }
    }
}
