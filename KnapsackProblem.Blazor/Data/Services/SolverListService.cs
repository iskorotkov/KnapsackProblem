using Blazor.FileReader;
using Knapsack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace KnapsackProblem.BlazorApp.Data.Services
{
    /// <summary>
    /// Хранилище всех алгоритмов решения задачи.
    /// </summary>
    public class SolverListService
    {
        /// <summary>
        /// Список всех алгоритмов.
        /// </summary>
        public List<ISolver> Implementations { get; } = new List<ISolver>();

        /// <summary>
        /// Выбранный в данный момент алгоритм.
        /// </summary>
        public ISolver Selected { get; private set; }

        /// <summary>
        /// Вызывается, когда был добавлен один или несколько алгоритмов.
        /// </summary>
        public event Action ImplementationAdded;

        /// <summary>
        /// Извлечь все алгоритмы решения из предоставленной DLL.
        /// </summary>
        /// <param name="file">Ссылка на выбранный DLL файл.</param>
        /// <exception cref="NoImplementationException">В предоставленной DLL не было ни одного алгоритма решения</exception>
        /// <exception cref="BadImageFormatException">Выбранный файл не является DLL или собран с более новой версией среды выполнения</exception>
        public async Task AddFromFile(IFileReference file)
        {
            var addedImplementations = 0;
            await using (var stream = await file.CreateMemoryStreamAsync())
            {
                var bytes = stream.ToArray();
                var assembly = Assembly.Load(bytes);
                var solverTypes = assembly
                    .GetExportedTypes()
                    .Where(t => typeof(ISolver).IsAssignableFrom(t))
                    .ToList();
                foreach (var type in solverTypes)
                {
                    ISolver solver;
                    try
                    {
                        solver = (ISolver) Activator.CreateInstance(type);
                    }
                    catch
                    {
                        continue;
                    }

                    if (solver != null)
                    {
                        Implementations.Add(solver);
                        addedImplementations++;
                    }
                }
            }

            if (addedImplementations == 0)
            {
                throw new NoImplementationException();
            }

            ImplementationAdded?.Invoke();
        }

        /// <summary>
        /// Устанавливает алгоритм из списка <see cref="Implementations"/> как выбранный в данный момент.
        /// </summary>
        /// <param name="index">Индекс алгоритма в списке.</param>
        /// <exception cref="IndexOutOfRangeException">Индекс выходит за границы массива <see cref="Implementations"/>.</exception>
        public void Select(int index)
        {
            Selected = Implementations[index];
        }

        /// <summary>
        /// Очищает выбор алгоритма.
        /// </summary>
        public void Deselect()
        {
            Selected = null;
        }
    }
}
