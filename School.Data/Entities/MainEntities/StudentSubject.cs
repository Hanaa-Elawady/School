namespace School.Data.Entities.MainEntities
{
    public class StudentSubject :GenericEntity
    {
        public Guid StudentId { get; set; }
        public Guid SubjectId { get; set; }
        public Student Student { get; set; }
        public Subject Subject { get; set; }

    }
}