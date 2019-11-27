using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PortalApi.DataBase.Model;
using PortalApi.DTO;
using PortalApi.Interfaces;
using System;

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

        public bool CreateUser(User user)
        {

            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UsersModel>());

            var mapper = config.CreateMapper();

            var newUser = mapper.Map<UsersModel>(user);

            try
            {
                Users.Add(newUser);

                SaveChanges();

                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        
        public bool AddCandidate(Candidate candidate)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Candidate, CandidatesModel>());

            var mapper = config.CreateMapper();

            var newCandidate = mapper.Map<CandidatesModel>(candidate);

            var recruiter = Candidates.Find(candidate.RecruiterId);
            newCandidate.RecruiterId = recruiter.RecruiterId;
            newCandidate.JobId = candidate.JobId;
            try
            {
                Candidates.Add(newCandidate);

                SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ValidatePassword(string user, string password)
        {
            try
            {
                var userToValid = Users.Find(user);
                return userToValid.Password == password;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
