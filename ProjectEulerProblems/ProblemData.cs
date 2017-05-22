namespace ProjectEulerProblems
{
    public class ProblemData
    {
        public ProblemData(string id, string description, string details)
        {
            Id = id;
            Description = description;
            Details = details;
        }

        public string Id  { get; }

        public string Description { get; }

        public string Details { get; }
    }
}
