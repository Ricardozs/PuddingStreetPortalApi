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

        public bool CreateUser(UsersModel user)
        {
            try
            {
                Users.Add(user);

                SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddCandidate(CandidatesModel candidate)
        {
            try
            {
                Candidates.Add(candidate);

                SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddJob(JobsModel job)
        {
            try
            {
                Jobs.Add(job);
                SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddCompetency(string name)
        {
            var competency = new CompetenciesModel
            {
                Name = name
            };
            try
            {
                Competencies.Add(competency);
                SaveChanges();
                return true;
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

        public List<CompetenciesTotal> GetCompetencies()
        {
            var competenciesTotals = new List<CompetenciesTotal>();
            try
            {
                foreach(var competency in Competencies)
                {
                    var newCompetency = new CompetenciesTotal
                    {
                        Name = competency.Name
                    };
                    competenciesTotals.Add(newCompetency);
                }
                foreach(var competency in competenciesTotals)
                {
                    competency.Candidates = Candidates.Where(x => x.Job.Competency.Name == competency.Name).Count();
                    competency.Assessments = Candidates.Where(x => x.Job.Competency.Name == competency.Name && x.Status == "Assessment Completed").Count();
                }
                return competenciesTotals;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool ValidatePassword(string user, string password)
        {
            try
            {
                var userToValid = Users.FirstOrDefault(x => x.UserName == user);
                return userToValid.Password == password;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
