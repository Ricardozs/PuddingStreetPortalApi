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
            try
            {
                var response = await DbContext.AddJob(newJob);
                return response == 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddCompetency(string name, Skill[] skills)
        {
            var newSkills = Mapper.Map<IEnumerable<SkillSetModel>>(skills);
            return true;
        }
        public async Task<List<CompetenciesTotal>> GetCompetencies()
        {
            var candidates = await DbContext.GetCompetencies();
            return candidates;
        }
    }
}
