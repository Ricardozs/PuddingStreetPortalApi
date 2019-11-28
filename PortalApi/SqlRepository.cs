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

        public bool CreateUser(User user)
        {

            var newUser = Mapper.Map<UsersModel>(user);

            try
            {
                return DbContext.CreateUser(newUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool AddCandidate(Candidate candidate)
        {
            var newCandidate = Mapper.Map<CandidatesModel>(candidate);
            try
            {
                return DbContext.AddCandidate(newCandidate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool AddJob(Job job)
        {
            var newJob = Mapper.Map<JobsModel>(job);
            try
            {
                return DbContext.AddJob(newJob);
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
    }
}
