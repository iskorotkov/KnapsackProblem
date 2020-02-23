using Blazor.FileReader;
using System.Collections.Generic;

namespace KnapsackProblem.Blazor.Data
{
    public class ImplementationRegistry
    {
        public List<IFileReference> Implementations { get; } = new List<IFileReference>();

        public void Add(IFileReference file)
        {
            Implementations.Add(file);
        }
    }
}
