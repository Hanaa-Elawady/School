namespace School.Services.Mapping.Dtos.Subjects
{
    public class SubjectDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int CreditHours { get; set; }
        public string Description { get; set; }
    }
}
