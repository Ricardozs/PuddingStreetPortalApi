using AutoMapper;
using PortalApi.DataBase.Model;
using PortalApi.DTO;
using PortalApi.DTO.Enum;
using PortalApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalApi
{
    public class SqlRepository : ISqlRepository
    {
        #region Private Properties
        private readonly IDbContext DbContext;
        private readonly IMapper Mapper;
        #endregion

        #region Constructor
        public SqlRepository(IDbContext dbContext, IMapper mapper)
        {
            DbContext = dbContext;
            Mapper = mapper;
        }
        #endregion

        #region Add or create methods
        public async Task<bool> CreateUser(User user)
        {

            var newUser = Mapper.Map<UsersModel>(user);

            try
            {
                var response = await DbContext.CreateUser(newUser);
                return response == 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> AddCandidate(Candidate candidate)
        {
            var newCandidate = Mapper.Map<CandidatesModel>(candidate);
            try
            {
                var response = await DbContext.AddCandidate(newCandidate, candidate.Job, candidate.Recruiter);
                return response == 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> AddJob(Job job)
        {
            var newJob = Mapper.Map<JobsModel>(job);
            newJob.Skills = new List<SkillSetModel>();
            try
            {
                foreach(var skill in job.Skills)
                {
                    var newSkill = new SkillSetModel
                    {
                        Name = skill.Name
                    };
                    newJob.Skills.Add(newSkill);
                }
                var response = await DbContext.AddJob(newJob, job.CompetencyName);
                return response == 6;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> AddCompetency(string name)
        {
            var response = await DbContext.AddCompetency(name);
            return response == 1;
        }
        #endregion

        #region Get methods
        public async Task<List<CompetenciesTotal>> GetCompetencies()
        {
            var candidates = await DbContext.GetCompetencies();
            return candidates;
        }
        public async Task<List<string>> GetJobs()
        {
            var jobs = await DbContext.GetJobs();
            return jobs.Select(x => x.Description).ToList();
        }
        public async Task<List<string>> GetCompetenciesNames()
        {
            var jobs = await DbContext.GetCompetenciesNames();
            return jobs.Select(x => x.Name).ToList();
        }
        #endregion

        public async Task<bool> ValidatePassword(LogInData logInData)
        {
            var result = await DbContext.ValidatePassword(logInData);
            return result;
        }


    }
}
