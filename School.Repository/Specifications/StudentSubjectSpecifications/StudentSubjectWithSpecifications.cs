using School.Data.Entities.MainEntities;
using School.Repository.Specifications.SpecificationsBase;

namespace School.Repository.Specifications.StudentSubjectSpecifications
{
    public class StudentSubjectWithSpecifications : BaseSpecifications<StudentSubject>
    {
        
        public StudentSubjectWithSpecifications(StudentSubjectSpecifications specs)
            : base(ss=>(!specs.subjectId.HasValue || ss.SubjectId == specs.subjectId.Value)
                        &&(!specs.studentId.HasValue || ss.StudentId == specs.studentId.Value)
            )
        {
            
            AddInclude(x => x.Subject.Name);
            AddInclude(x => x.Student);
        }
    }
}
