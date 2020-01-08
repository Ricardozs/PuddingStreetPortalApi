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
        Task<int> AddCandidate(CandidatesModel candidate, string jobDescription, string recruiter);
        Task<int> AddJob(JobsModel job, string competencyName);
        Task<int> AddCompetency(string name);
        Task<List<CandidatesModel>> GetCandidates();
        Task<List<CompetenciesTotal>> GetCompetencies();
        Task<List<JobsModel>> GetJobs();
        Task<List<CompetenciesModel>> GetCompetenciesNames();
        Task<bool> ValidatePassword(LogInData logInData);
    }
}
