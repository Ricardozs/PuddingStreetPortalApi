using PortalApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalApi.Interfaces
{
    public interface ISqlRepository
    {
        bool CreateUser(User user);
        bool AddCandidate(Candidate candidate);
        bool AddJob(Job job);
        bool AddCompetency(string name, Skill[] skills);
        List<CompetenciesTotal> GetCompetencies();
    }
}
