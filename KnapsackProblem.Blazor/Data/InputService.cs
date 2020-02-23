using System;
using Blazor.FileReader;
using KnapsackProblem.BlazorApp.Data.Knapsack;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace KnapsackProblem.BlazorApp.Data
{
    public class InputService
    {
        public KnapsackInput Input { get; private set; }

        public async Task SetFromFile(IFileReference file)
        {
            await using var stream = await file.CreateMemoryStreamAsync(4096);
            using var reader = new StreamReader(stream);
            var content = reader.ReadToEnd();
            if (file is IDisposable obj)
            {
                obj.Dispose();
            }

            Input = JsonConvert.DeserializeObject<KnapsackInput>(content);
        }
    }
}
