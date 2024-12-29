using AutoMapper;
using School.Data.Entities.MainEntities;
using School.Services.Mapping.Dtos.Subjects;

namespace School.Services.Mapping.Profiles
{
    public class SubjectProfile :Profile
    { 
        public SubjectProfile()
        {
            CreateMap<Subject , SubjectDto>().ReverseMap();
        }
    }
}
