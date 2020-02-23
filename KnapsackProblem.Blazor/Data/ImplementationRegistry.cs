using Blazor.FileReader;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnapsackProblem.BlazorApp.Data
{
    public class ImplementationRegistry
    {
        public List<IFileReference> Implementations { get; } = new List<IFileReference>();

        public async Task Add(IFileReference file)
        {
            Implementations.Add(file);
        }
    }
}
