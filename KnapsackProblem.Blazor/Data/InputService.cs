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
        private IFileReference _file;

        public async Task<KnapsackInput> Input()
        {
            await using var stream = await _file.CreateMemoryStreamAsync(4096);
            using var reader = new StreamReader(stream);
            var content = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<KnapsackInput>(content);
        }

        public void SetFromFile(IFileReference file)
        {
            if (_file is IDisposable obj)
            {
                obj.Dispose();
            }
            _file = file;
        }
    }
}
