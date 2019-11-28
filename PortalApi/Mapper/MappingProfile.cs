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
            CreateMap<Job, JobsModel>().ForMember(m => m.RecruitingType, opt => opt.MapFrom(src => src.RecruitingType + 1));
            CreateMap<JobsModel, Job>().ForMember(m => m.RecruitingType, opt => opt.MapFrom(src => src.RecruitingType - 1));
            CreateMap<User, UsersModel>().ForMember(m => m.UserType, opt => opt.MapFrom(src => src.UserType + 1));
            CreateMap<UsersModel, User>().ForMember(m => m.UserType, opt => opt.MapFrom(src => src.UserType - 1));
            CreateMap<CandidatesModel[], IEnumerable<Candidate>>();
            CreateMap<IEnumerable<Candidate>, CandidatesModel[]>();
            CreateMap<Skill[], IEnumerable<SkillSetModel>>();
            CreateMap<IEnumerable<SkillSetModel>, Skill[]>();
        }
    }
}
