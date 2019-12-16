using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PortalApi.DataBase.Model
{
    [Table("Competencies")]
    public class CompetenciesModel
    {
        [Key]
        [Column("CompetencyId")]
        public int CompetencyId { get; set; }

        [Column("Name")]
        public string Name { get; set; }
    }
}
