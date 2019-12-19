using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PortalApi.DataBase.Model;
using PortalApi.DTO;
using PortalApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalApi.DataBase
{
    public class PortalContext : DbContext, IDbContext
    {
        public PortalContext(DbContextOptions options) : base(options)
        {

        }
        private DbSet<UsersModel> Users { get; set; }

        private DbSet<CandidatesModel> Candidates { get; set; }

        private DbSet<UserTypesModel> UserTypes { get; set; }

        private DbSet<CompetenciesModel> Competencies { get; set; }

        private DbSet<JobsModel> Jobs { get; set; }

        private DbSet<SkillsAssessmentsModel> SkillsAssessments { get; set; }

        private DbSet<SkillSetModel> Skills { get; set; }

        public async Task<int> CreateUser(UsersModel user)
        {
            try
            {
                Users.Add(user);

                SaveChanges();

                return await SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> AddCandidate(CandidatesModel candidate)
        {
            try
            {
                Candidates.Add(candidate);


                return await SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> AddJob(JobsModel job, string competencyName)
        {
            try
            {
                job.Competency = Competencies.FirstOrDefault(x => x.Name == competencyName);
                job.CompetencyId = job.Competency.CompetencyId;
                Jobs.Add(job);
                return await SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> AddCompetency(string name)
        {
            var competency = new CompetenciesModel
            {
                Name = name
            };
            try
            {
                Competencies.Add(competency);
                return await SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Candidate[] GetCandidatesByStatus(string status)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Candidate, CandidatesModel>());

            var mapper = config.CreateMapper();

            var response = mapper.Map<CandidatesModel[], IEnumerable<Candidate>>(Candidates.Where(x => x.Status == status).ToArray());
            return response.ToArray();
        }

        public async Task<List<CompetenciesTotal>> GetCompetencies()
        {
            try
            {
                var result = Task.Run( () => GetTotals());
                return await result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private List<CompetenciesTotal> GetTotals()
        {
            var competenciesTotals = new List<CompetenciesTotal>();
            try
            {
                foreach (var competency in Competencies)
                {
                    var newCompetency = new CompetenciesTotal
                    {
                        Name = competency.Name
                    };
                    competenciesTotals.Add(newCompetency);
                }
                foreach (var competency in competenciesTotals)
                {
                    competency.Candidates = Candidates.Where(x => x.Job.Competency.Name == competency.Name).Count();
                    competency.Assessments = Candidates.Where(x => x.Job.Competency.Name == competency.Name && x.Status == "Assessment Completed").Count();
                }
                return competenciesTotals;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ValidatePassword(LogInData logInData)
        {
            try
            {
                var userToValid = Task.Run(() => Users.FirstOrDefault(x => x.UserName == logInData.User));
                var response = Task.Run(() => userToValid.Result.Password == logInData.Password);
                return await response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
