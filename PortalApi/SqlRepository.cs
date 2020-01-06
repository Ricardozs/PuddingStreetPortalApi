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
        IDbContext DbContext;
        IMapper Mapper;

        public SqlRepository(IDbContext dbContext, IMapper mapper)
        {
            DbContext = dbContext;
            Mapper = mapper;
        }

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
                var response = await DbContext.AddCandidate(newCandidate);
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
        public async Task<List<CompetenciesTotal>> GetCompetencies()
        {
            var candidates = await DbContext.GetCompetencies();
            return candidates;
        }

        public async Task<bool> ValidatePassword(LogInData logInData)
        {
            var result = await DbContext.ValidatePassword(logInData);
            return result;
        }
    }
}
