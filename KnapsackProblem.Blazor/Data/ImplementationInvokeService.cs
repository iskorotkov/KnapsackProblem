using System.Linq;

namespace KnapsackProblem.BlazorApp.Data
{
    public class ImplementationInvokeService
    {
        private readonly InputService _inputService;
        private readonly ImplementationRegistryService _registry;

        public ImplementationInvokeService(InputService inputService, ImplementationRegistryService registry)
        {
            _inputService = inputService;
            _registry = registry;
        }

        public bool[] InvokeSelected()
        {
            var implementation = _registry.Selected;
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
