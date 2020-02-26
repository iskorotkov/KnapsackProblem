namespace KnapsackProblem.BlazorApp.Data.Implementations
{
    public interface ISolver
    {
        bool[] Solve(int M, int[] m, int[] c);
        string GetName();
    }
}
