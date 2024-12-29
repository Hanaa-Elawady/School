namespace School.Repository.Specifications.SubjectSpecifications
{
    public class SubjectSpecifications
    {
        private string? _Search;

        public string? Search
        {
            get => _Search;
            set => _Search = value?.Trim().ToLower();
        }
    }
}
