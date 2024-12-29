namespace School.Repository.Specifications.StudentSpecifications
{
    public class StudentSpecification
    {
        public string? Sort { get; set; }

        private string? _Search;

        public string? Search
        {
            get => _Search;
            set => _Search = value?.Trim().ToLower();
        }
    }
}
