using AutoMapper;
using School.Data.Entities.MainEntities;
using School.Repository.Interfaces;
using School.Repository.Specifications.StudentSpecifications;
using School.Services.Mapping.Dtos.Students;

namespace School.Services.Services.Students
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentService(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<StudentDto> AddStudentAsync(StudentDto student)
        {
            student.Id = new Guid();
            var mappedStudent = _mapper.Map<Student>(student);

            await _unitOfWork.Repository<Student>().AddAsync(mappedStudent);
            await _unitOfWork.CompleteAsync();
            var newStudent = await GetStudentByIdAsync(mappedStudent.Id);
            return newStudent;
        }

        public async Task<string> AddSubjectToStudent(Guid studentId  ,Guid subjectId)
        {
            var studentSubject = new StudentSubject
            {
                StudentId = studentId,
                SubjectId = subjectId
            };
            await _unitOfWork.Repository<StudentSubject>().AddAsync(studentSubject);
            var result =await _unitOfWork.CompleteAsync();
            if (result != 1)
                throw new Exception("Error Adding the Subject");

            return $"Subject Added successfully";

        }

        public async Task<string> DeleteStudent(Guid studentId)
        {
            var studentToRemove = await _unitOfWork.Repository<Student>().GetByIdAsync(studentId);
            if (studentToRemove == null)
                throw new Exception("No Student found with this Id ");

            _unitOfWork.Repository<Student>().Delete(studentToRemove);
            var result = await _unitOfWork.CompleteAsync();
            if (result != 1)
                throw new Exception("Delete Failed please Try again Later ");

           return $"succeeded";
        }

        public async Task<IEnumerable<StudentDto>> GetAllStudentsAsync(StudentSpecification input)
        {
            var specs = new StudentWithSpecifications(input);
            var students =await _unitOfWork.Repository<Student>().GetAllAsNoTrackingWithSpecsAsync(specs);
            if (!students.Any())
                throw new Exception("No students Found");

            var mappedStudents = _mapper.Map<IEnumerable<StudentDto>>(students);
            return mappedStudents;
        }

        public async Task<StudentDto> GetStudentByIdAsync(Guid id)
        {
            var specs = new StudentWithSpecifications(id);

            var student = await _unitOfWork.Repository<Student>().GetAllAsNoTrackingWithSpecsAsync(specs);
            if (student == null)
                throw new Exception("No Student found with this Id ");

            var mappedStudent = _mapper.Map<StudentDto>(student.First());
            return mappedStudent;
        }

        public async Task<StudentDto> UpdateStudent(StudentDto student)
        {
            var studentToUpdate = _mapper.Map<Student>(student);
            _unitOfWork.Repository<Student>().Update(studentToUpdate);
            var result = await _unitOfWork.CompleteAsync();
            if (result != 1) throw new Exception("Update Failed please Try again Later ");
            
            var updatesStudent = await GetStudentByIdAsync(studentToUpdate.Id);
            return updatesStudent;


        }
    }
}
