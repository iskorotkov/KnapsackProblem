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
        public ISolver Selected { get; set; }

        public async Task Add(IFileReference file)
        {
            using var stream = await file.CreateMemoryStreamAsync();
            var bytes = stream.ToArray();
            var assembly = Assembly.Load(bytes);
            var solverTypes = assembly
                .GetExportedTypes()
                .Where(t => typeof(ISolver).IsAssignableFrom(t));
            foreach (var type in solverTypes)
            {
                var solver = (ISolver)Activator.CreateInstance(type);
                Implementations.Add(solver);
            }
        }
    }
}
