using Blazor.FileReader;
using Knapsack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace KnapsackProblem.BlazorApp.Data
{
    public class ImplementationRegistryService
    {
        public List<ISolver> Implementations { get; } = new List<ISolver>();
        public ISolver Selected { get; private set; }

        public event Action ImplementationAdded;

        public async Task Add(IFileReference file)
        {
            List<Type> solverTypes;
            await using (var stream = await file.CreateMemoryStreamAsync())
            {
                var bytes = stream.ToArray();
                var assembly = Assembly.Load(bytes);
                solverTypes = assembly
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

                    if (solver != null) Implementations.Add(solver);
                }
            }

            if (solverTypes.Count == 0) throw new NoImplementationException();
            ImplementationAdded?.Invoke();
        }

        public void Select(int index)
        {
            Selected = Implementations[index];
        }

        public void Deselect()
        {
            Selected = null;
        }
    }
}
