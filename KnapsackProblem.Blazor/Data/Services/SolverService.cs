using System.Linq;
using KnapsackProblem.BlazorApp.Data.Services;

namespace KnapsackProblem.BlazorApp.Data.Services
{
    /// <summary>
    /// Сервис, позволяющий подготовить входные данные и передать их выбранному алгоритму решения.
    /// </summary>
    public class SolverService
    {
        private readonly InputService _inputService;
        private readonly SolverListService _registry;

        public SolverService(InputService inputService, SolverListService registry)
        {
            _inputService = inputService;
            _registry = registry;
        }

        /// <summary>
        /// Использовать выбранный в данный момент алгоритм для обработки входных данных.
        ///
        /// Выбранный алгоритм опрелеляется экземпляром <see cref="SolverListService"/>,
        /// а используемые данные - экземпляром <see cref="InputService"/>.
        /// </summary>
        /// <returns>Массив флагов, показывающих, нужно ли класть в рюкзак объект с данным индексом</returns>
        public bool[] Solve()
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
