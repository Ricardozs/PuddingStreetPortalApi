using PortalApi.DTO.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalApi.DTO
{
    public class Job
    {
        public string Description { get; set; }
        public string Client { get; set; }
        public RecruitingType RecruitingType { get; set; }
        public string CompetencyName { get; set; }
    }
}
