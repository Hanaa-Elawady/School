using School.Services.Mapping.Dtos.Subjects;

namespace School.Services.Services.Subjects
{
    public interface ISubjectService
    {
        public Task<IEnumerable<SubjectDto>> GetAllSubjectsAsync();
        public Task<SubjectDto> GetSubjectByIdAsync(Guid id);
        public Task<SubjectDto> AddSubjectAsync(SubjectDto subject);
        public Task<SubjectDto> UpdateSubject(SubjectDto subject);
        public Task<string> DeleteSubject(Guid subjectId);
    }
}
