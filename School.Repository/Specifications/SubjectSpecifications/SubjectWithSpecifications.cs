using School.Data.Entities.MainEntities;
using School.Repository.Specifications.SpecificationsBase;

namespace School.Repository.Specifications.SubjectSpecifications
{
    public class SubjectWithSpecifications : BaseSpecifications<Subject>
    {
        public SubjectWithSpecifications(SubjectSpecifications specs) 
            : base(s=>(string.IsNullOrEmpty(specs.Search) || s.Name.Trim().ToLower().Contains(specs.Search))
                  )
        {
            AddInclude(s => s.StudentSubjects);
        }
        public SubjectWithSpecifications(Guid id):base(s=>s.Id ==id) 
        {
            AddInclude(s => s.StudentSubjects);
        }
    }
}
