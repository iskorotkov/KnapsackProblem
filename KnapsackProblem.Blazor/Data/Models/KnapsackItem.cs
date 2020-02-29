namespace KnapsackProblem.BlazorApp.Data.Models
{
    /// <summary>
    /// Объект, который может быть помещен в рюкзак.
    /// </summary>
    public class KnapsackItem
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Cost { get; set; }
    }
}
