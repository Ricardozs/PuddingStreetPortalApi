using AutoMapper;
using PortalApi.DataBase.Model;
using PortalApi.DTO;
using PortalApi.DTO.Enum;
using PortalApi.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalApi.Mapper
{
    public class MappingProfile : Profile, IValueConverter<string, Skill>
    {
        public MappingProfile()
        {
            CreateMap<Candidate, CandidatesModel>().ReverseMap();
            CreateMap<CandidateRequest, Candidate>().
                ForMember(m => m.HighestEducation, opt => opt.MapFrom
                    (src => src.HighestEducation == "diploma" ? HighestEducation.Diploma : 
                            src.HighestEducation == "bachelors" ? HighestEducation.Bachelors : 
                            src.HighestEducation == "masterOrHigher" ? HighestEducation.MasterOrHigher : HighestEducation.None)).
                ForMember(m => m.LegalStatus, opt => opt.MapFrom
                    (src => src.LegalStatus == "openWorkPermit" ? LegalStatus.OpenWorkPermit : 
                            src.LegalStatus == "closedWorkPermit" ? LegalStatus.ClosedWorkPermit :
                            src.LegalStatus == "permanentResident" ? LegalStatus.PermanentResident :
                            src.LegalStatus == "citizen" ? LegalStatus.Citizen : LegalStatus.None));
            CreateMap<JobRequest, Job>().
                ForMember(m => m.RecruitingType, opt => opt.MapFrom(src => src.RecruitingType == "pipeline" ? RecruitingType.Pipeline : RecruitingType.Sourcing)).
                ForMember(m => m.Skills, opt => opt.ConvertUsing(new SkillFormatter()));
            CreateMap<Job, JobsModel>().ForMember(m => m.RecruitingType, opt => opt.MapFrom(src => src.RecruitingType + 1)).
                ForMember(m => m.Skills, opt => opt.Ignore());
            CreateMap<JobsModel, Job>().ForMember(m => m.RecruitingType, opt => opt.MapFrom(src => src.RecruitingType - 1)).
                ForMember(m => m.Skills, opt => opt.Ignore());
            CreateMap<User, UsersModel>().ForMember(m => m.UserType, opt => opt.MapFrom(src => src.UserType + 1));
            CreateMap<UsersModel, User>().ForMember(m => m.UserType, opt => opt.MapFrom(src => src.UserType.Type - 1));
            CreateMap<CandidatesModel[], IEnumerable<Candidate>>();
            CreateMap<IEnumerable<Candidate>, CandidatesModel[]>();
            CreateMap<Skill[], IEnumerable<SkillSetModel>>();
            CreateMap<IEnumerable<SkillSetModel>, Skill[]>();
        }
        public Skill Convert(string source)
        {
            return new Skill
            {
                Name = source
            };
        }
        public Skill Convert(string sourceMember, ResolutionContext context) => throw new NotImplementedException();
    }

    public class SkillFormatter : IValueConverter<string[], Skill[]>
    {

        public Skill[] Convert(string[] sourceSkills, ResolutionContext context) 
        {

            var skills = new List<Skill>();
            foreach(var skill in sourceSkills)
            {
                var newSkill = new Skill
                {
                    Name = skill
                };
                skills.Add(newSkill);
            }
            return skills.ToArray();
        }
    }
}
