﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PortalApi.DataBase.Model
{
    [Table("SkillsAssessments")]
    public class SkillsAssessmentsModel
    {
        [Key]
        [Column("SkillAssessmentId")]
        public int SkillAssessmentId { get; set; }

        [Column("Grade")]
        public int Grade { get; set; }

        [ForeignKey("SkillSetModel")]
        [Column("SkillId")]
        public int SkillId { get; set; }
        public SkillSetModel Skill { get; set; }

        [ForeignKey("CandidatesModel")]
        [Column("CandidateId")]
        public int CandidateId { get; set; }
        public CandidatesModel Candidate { get; set; }
    }
}
