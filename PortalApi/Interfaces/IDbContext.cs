using PortalApi.DataBase.Model;
using PortalApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalApi.Interfaces
{
    public interface IDbContext
    {
        bool CreateUser(UsersModel user);
        bool AddCandidate(CandidatesModel candidate);
        bool AddJob(JobsModel job);
        bool AddCompetency(string name);
        Candidate[] GetCandidatesByStatus(string status);
        bool ValidatePassword(string user, string password);
    }
}
