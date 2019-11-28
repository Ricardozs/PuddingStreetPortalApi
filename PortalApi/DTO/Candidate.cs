using PortalApi.DTO.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalApi.DTO
{
    public class Candidate
    {
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string CurrentLocation { get; set; }
        public string Availability { get; set; }
        public string OverralExperience { get; set; }
        public string ITExperience { get; set; }
        public HighestEducation HighestEducation { get; set; }
        public LegalStatus LegalStatus { get; set; }
        public DateTime WorkPermitExpiration { get; set; }
        public string Notes { get; set; }
        public int RecruiterId { get; set; }
        public string Status { get; set; }
        public int JobId { get; set; }
        public int SkillAssessmentId { get; set; }
    }
}
