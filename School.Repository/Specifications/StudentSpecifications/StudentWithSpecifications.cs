using School.Data.Entities.MainEntities;
using School.Repository.Specifications.SpecificationsBase;

namespace School.Repository.Specifications.StudentSpecifications
{
    public class StudentWithSpecifications : BaseSpecifications<Student>
    {
        public StudentWithSpecifications(StudentSpecification specs)
            : base(student => (string.IsNullOrEmpty(specs.Search) || student.FirstName.Trim().ToLower().Contains(specs.Search)))

        {
            AddInclude(Student => Student.StudentSubjects);
            if (!string.IsNullOrEmpty(specs.Sort))
            {
                switch (specs.Sort)
                {
                    case "AgeAsc":
                        AddOrderBy(x => x.DateOfBirth);
                        break;
                    case "AgeDesc":
                        AddOrderByDescending(x => x.DateOfBirth);
                        break;
                    default:
                        AddOrderBy(x => x.FirstName);
                        break;

                }
            }
        }
        public StudentWithSpecifications(Guid Id)
        : base(student => student.Id == Id)

        {
            AddInclude(Student => Student.StudentSubjects);

        }
    }
}
