using PortalApi.DTO.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PortalApi.DataBase.Model
{
    [Table("Jobs")]
    public class JobsModel
    {
        [Key]
        [Column("JobId")]
        public int JobId { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        [Column("Client")]
        public string Client { get; set; }

        [Column("RecruitingType")]
        public RecruitingType RecruitingType { get; set; }

        [ForeignKey("CompetenciesModel")]
        [Column("CompetencyId")]
        public int CompetencyId { get; set; }
        public CompetenciesModel Competency { get; set; }
        public ICollection<CandidatesModel> Candidates { get; set; }
        public ICollection<SkillSetModel> Skills{ get; set; }
    }
}
