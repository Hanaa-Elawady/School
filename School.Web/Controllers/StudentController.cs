using Microsoft.AspNetCore.Mvc;
using School.Repository.Specifications.StudentSpecifications;
using School.Services.Mapping.Dtos.Students;
using School.Services.Services.Students;

namespace School.Web.Controllers
{

    public class StudentController : BaseController
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<StudentDto>>> GetAllStudents([FromQuery]StudentSpecification input)
        => Ok(await _studentService.GetAllStudentsAsync(input));

        [HttpGet]
        public async Task<ActionResult<StudentDto>> GetStudentById(Guid id)
        => Ok(await _studentService.GetStudentByIdAsync(id));


        [HttpPost]
        public async Task<ActionResult<StudentDto>> AddStudent(StudentDto student)
        => Ok(await _studentService.AddStudentAsync(student));
        [HttpPost]
        public async Task<ActionResult<string>> AddSubjectToStudent(Guid studentId ,Guid subjectId)
        { 
            return Ok(await _studentService.AddSubjectToStudent(studentId,subjectId));
        }

        [HttpPost]
        public async Task<ActionResult<StudentDto>> UpdateStudent(StudentDto student)
        => Ok(await _studentService.UpdateStudent(student));

        [HttpDelete]
        public async Task<ActionResult<string>> DeleteStudent(Guid studentId)
        => Ok(new{message = await _studentService.DeleteStudent(studentId)});
    }
}
