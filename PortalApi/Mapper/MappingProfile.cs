using AutoMapper;
using PortalApi.DataBase.Model;
using PortalApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalApi.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Candidate, CandidatesModel>();
            CreateMap<CandidatesModel, Candidate>();
            CreateMap<Job, JobsModel>();
            CreateMap<JobsModel, Job>();
            CreateMap<User, UsersModel>();
            CreateMap<UsersModel, User>();
            CreateMap<CandidatesModel[], IEnumerable<Candidate>>();
            CreateMap<IEnumerable<Candidate>, CandidatesModel[]>();
            CreateMap<Skill[], IEnumerable<SkillSetModel>>();
            CreateMap<IEnumerable<SkillSetModel>, Skill[]>();
        }
    }
}
