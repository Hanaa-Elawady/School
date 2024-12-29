namespace School.Data.Entities.MainEntities
{
    public class Subject : BaseEntity
    {
        public string Name { get; set; }
        public int CreditHours { get; set; }
        public string Description { get; set; }
        public ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}
