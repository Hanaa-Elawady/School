using AutoMapper;
using School.Data.Entities.MainEntities;
using School.Repository.Interfaces;
using School.Services.Mapping.Dtos.Subjects;

namespace School.Services.Services.Subjects
{
    public class SubjectService : ISubjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SubjectService(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SubjectDto> AddSubjectAsync(SubjectDto subject)
        {
            var mappedSubject = _mapper.Map<Subject>(subject);
            await _unitOfWork.Repository<Subject>().AddAsync(mappedSubject);
            await _unitOfWork.CompleteAsync();
            var newSubject = await GetSubjectByIdAsync(mappedSubject.Id);
            return newSubject;
        }

        public async Task<string> DeleteSubject(Guid subjectId)
        {
            var subjectToRemove = await _unitOfWork.Repository<Subject>().GetByIdAsync(subjectId);
            if (subjectToRemove == null)
                throw new Exception("No Subject found with this Id ");

            _unitOfWork.Repository<Subject>().Delete(subjectToRemove);
            var result = await _unitOfWork.CompleteAsync();
            if (result != 1)
                throw new Exception("Delete Failed please Try again Later ");

            return $"{subjectToRemove.Name} subject deleted successfully";
        }

        public async Task<IEnumerable<SubjectDto>> GetAllSubjectsAsync()
        {
            var subjects = await _unitOfWork.Repository<Subject>().GetAllAsync();
            if (!subjects.Any())
                throw new Exception("No subjects Found");

            var mappedSubjects = _mapper.Map<IEnumerable<SubjectDto>>(subjects);
            return mappedSubjects;
        }

        public async Task<SubjectDto> GetSubjectByIdAsync(Guid id)
        {
            var subject = await _unitOfWork.Repository<Subject>().GetByIdAsync(id);
            if (subject == null)
                throw new Exception("No Subject found with this Id ");

            var mappedSubject = _mapper.Map<SubjectDto>(subject);
            return mappedSubject;
        }

        public async Task<SubjectDto> UpdateSubject(SubjectDto subject)
        {
            var subjectToUpdate = _mapper.Map<Subject>(subject);
            _unitOfWork.Repository<Subject>().Update(subjectToUpdate);
            var result = await _unitOfWork.CompleteAsync();
            if (result != 1) throw new Exception("Update Failed please Try again Later ");

            var updatesSubject = await GetSubjectByIdAsync(subjectToUpdate.Id);
            return updatesSubject;
        }
    }
}
