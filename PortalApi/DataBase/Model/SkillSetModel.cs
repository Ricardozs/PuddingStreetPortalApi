using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PortalApi.DataBase.Model
{
    [Table("SkillSet")]
    public class SkillSetModel
    {
        [Key]
        [Column("SkillId")]
        public int SKillId { get; set; }

        [Column("Name")]
        public string Name { get; set; }
        [Column("JobId")]
        public int JobId { get; set; }
        public JobsModel Job { get; set; }

        public ICollection<SkillsAssessmentsModel> Assessments { get; set; }
        
    }
}
