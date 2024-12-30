using Microsoft.AspNetCore.Mvc;
using School.Services.Mapping.Dtos.Subjects;
using School.Services.Services.Subjects;

namespace School.Web.Controllers
{
    public class SubjectController : BaseController
    {

        private readonly ISubjectService _subjectService;
        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<SubjectDto>>> GetAllSubjects()
        => Ok(await _subjectService.GetAllSubjectsAsync());

        [HttpGet]
        public async Task<ActionResult<SubjectDto>> GetSubjectById(Guid id)
        => Ok(await _subjectService.GetSubjectByIdAsync(id));


        [HttpPost]
        public async Task<ActionResult<SubjectDto>> AddSubject(SubjectDto subject)
        => Ok(await _subjectService.AddSubjectAsync(subject));

        [HttpPost]
        public async Task<ActionResult<SubjectDto>> UpdateSubject(SubjectDto subject)
        => Ok(await _subjectService.UpdateSubject(subject));

        [HttpDelete]
        public async Task<ActionResult<string>> DeleteSubject(Guid subjectId)
        => Ok(new{message = await _subjectService.DeleteSubject(subjectId)});
    }
}
