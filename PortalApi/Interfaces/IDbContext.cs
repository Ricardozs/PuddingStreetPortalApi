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
        Task<int> CreateUser(UsersModel user);
        Task<int> AddCandidate(CandidatesModel candidate);
        Task<int> AddJob(JobsModel job, string competencyName);
        Task<int> AddCompetency(string name);
        Candidate[] GetCandidatesByStatus(string status);
        Task<List<CompetenciesTotal>> GetCompetencies();
        Task<bool> ValidatePassword(LogInData logInData);
    }
}
