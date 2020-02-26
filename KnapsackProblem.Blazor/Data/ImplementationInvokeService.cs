using KnapsackProblem.BlazorApp.Data.Implementations;
using System.Linq;

namespace KnapsackProblem.BlazorApp.Data
{
    public class ImplementationInvokeService
    {
        private readonly InputService _inputService;

        public ImplementationInvokeService(InputService inputService)
        {
            _inputService = inputService;
        }

        public bool[] InvokeSelected(ISolver implementation)
        {
            var input = _inputService.Input;

            var maxWeight = input.Knapsack.MaxWeight;
            var weights = input.Items
                .Select(it => it.Weight)
                .ToArray();
            var costs = input.Items
                .Select(it => it.Cost)
                .ToArray();

            return implementation.Solve(maxWeight, weights, costs);
        }
    }
}
