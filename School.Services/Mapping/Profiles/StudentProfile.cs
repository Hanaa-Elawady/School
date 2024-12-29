using AutoMapper;
using School.Data.Entities.MainEntities;
using School.Services.Mapping.Dtos.Students;

namespace School.Services.Mapping.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<StudentDto, Student>()
                .ForMember(dest => dest.StudentSubjects, opt => opt.Ignore());
            CreateMap<Student, StudentDto>().ForMember(dest => dest.SubjectsId, options => options.MapFrom(src => src.StudentSubjects.Select(s=>s.SubjectId)));


        }
    }
}
