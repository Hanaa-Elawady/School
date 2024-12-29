using School.Repository.Specifications.SpecificationsBase;
using School.Repository.Specifications.StudentSpecifications;
using School.Services.Mapping.Dtos.Students;

namespace School.Services.Services.Students
{
    public interface IStudentService
    {
        public Task<IEnumerable<StudentDto>> GetAllStudentsAsync(StudentSpecification specs);
        public Task<StudentDto> GetStudentByIdAsync(Guid id);
        public Task<StudentDto> AddStudentAsync(StudentDto student);
        public Task<string> AddSubjectToStudent(Guid studentId,Guid subjectId);
        public Task<StudentDto> UpdateStudent(StudentDto student);
        public Task<string> DeleteStudent(Guid studentId);
    }
}
