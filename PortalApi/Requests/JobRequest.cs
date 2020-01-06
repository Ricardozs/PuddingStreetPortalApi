using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalApi.Requests
{
    public class JobRequest
    {
        public string Description { get; set; }
        public string Client { get; set; }
        public string RecruitingType { get; set; }
        public string CompetencyName { get; set; }
        public string[] Skills { get; set; }
    }
}
