using PortalApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalApi.Interfaces
{
    public interface ISqlRepository
    {
        Task<bool> CreateUser(User user);
        Task<bool> AddCandidate(Candidate candidate);
        Task<bool> AddJob(Job job);
        Task<bool> AddCompetency(string name);
        Task<List<CompetenciesTotal>> GetCompetencies();
        Task<List<string>> GetJobs();
        Task<List<string>> GetCompetenciesNames();
        Task<bool> ValidatePassword(LogInData logInData);
    }
}
