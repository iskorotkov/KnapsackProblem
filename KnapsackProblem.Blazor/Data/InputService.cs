using Blazor.FileReader;
using KnapsackProblem.BlazorApp.Data.Knapsack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace KnapsackProblem.BlazorApp.Data
{
    public class InputService
    {
        public KnapsackInput Input { get; private set; } = new KnapsackInput
        {
            Knapsack = new Knapsack.Knapsack(),
            Items = new List<KnapsackItem>()
        };

        public event Action InputUpdated;

        public async Task SetFromFile(IFileReference file)
        {
            await using var stream = await file.CreateMemoryStreamAsync(4096);
            using var reader = new StreamReader(stream);
            var content = reader.ReadToEnd();
            // ReSharper disable once SuspiciousTypeConversion.Global
            if (file is IDisposable obj)
            {
                obj.Dispose();
            }

            var decerialized = JsonConvert.DeserializeObject<KnapsackInput>(content);
            if (decerialized?.Items == null || decerialized.Knapsack == null)
            {
                throw new InvalidInputFileException();
            }

            Input = decerialized;
            InputUpdated?.Invoke();
        }
    }
}
