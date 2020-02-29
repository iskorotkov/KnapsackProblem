using System.Collections.Generic;

namespace KnapsackProblem.BlazorApp.Data.Models
{
    /// <summary>
    /// Совокупность всех входных данных, которая будет читаться из файла.
    ///
    /// Предоставляет информацию о рюкзаке и об объектах, которые будут складываться в рюкзак.
    /// </summary>
    public class KnapsackInput
    {
        public Knapsack Knapsack { get; set; }
        public List<KnapsackItem> Items { get; set; }
    }
}
