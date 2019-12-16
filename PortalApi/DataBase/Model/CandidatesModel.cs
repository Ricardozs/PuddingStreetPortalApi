using PortalApi.DTO.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalApi.DataBase.Model
{
    [Table("Candidates")]
    public class CandidatesModel
    {
        [Key]
        [Column("CandidateId")]
        public string CandidateId { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("PhoneNumber")]
        public int PhoneNumber { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("CurrentLocation")]
        public string CurrentLocation { get; set; }

        [Column("Availability")]
        public string Availability { get; set; }

        [Column("OverralExperience")]
        public string OverralExperience { get; set; }
        [Column("ITExperience")]
        public string ITExperience { get; set; }

        [Column("Education")]
        public HighestEducation Education { get; set; }

        [Column("LegalStatus")]
        public LegalStatus LegalStatus { get; set; }

        [Column("WorkPermitExpiration")]
        public DateTime WorkPermitExpiration { get; set; }

        [Column("Notes")]
        public string Notes { get; set; }

        [ForeignKey("UsersModel")]
        [Column("RecruiterId")]
        public int RecruiterId { get; set; }

        [Column("Status")]
        public string Status { get; set; }

        [ForeignKey("JobsModel")]
        [Column("JobId")]
        public int JobId { get; set; }
        public JobsModel Job { get; set; }

        [ForeignKey("SkillsAssessmentsModel")]
        [Column("SkillAssessmentId")]
        public int SkillAssessmentId { get; set; }
        public SkillsAssessmentsModel skillsAssessments { get; set; }
    }
}
