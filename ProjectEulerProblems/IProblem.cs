namespace ProjectEulerProblems
{
    public interface IProblem
    {
        int ProblemId { get; }

        double GetSolution();
    }
}
