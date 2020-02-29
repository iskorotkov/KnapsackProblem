using Blazor.FileReader;
using KnapsackProblem.BlazorApp.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace KnapsackProblem.BlazorApp.Data.Services
{
    /// <summary>
    /// Сервис, отвечающий за обработку ввода из файла.
    /// </summary>
    public class InputService
    {
        /// <summary>
        /// Набор входных данных.
        /// </summary>
        public KnapsackInput Input { get; private set; } = new KnapsackInput
        {
            Knapsack = new Models.Knapsack(),
            Items = new List<KnapsackItem>()
        };

        /// <summary>
        /// Вызывается, когда из файла был прочитан новый набор входных данных.
        ///
        /// Вызывается только в том случае, если в файле находились входные данные в требуемом формате.
        /// </summary>
        public event Action InputUpdated;

        /// <summary>
        /// Прочитать входные данные из файла, обработать их и сохранить для последующих действий.
        /// </summary>
        /// <param name="file">Ссылка на выбранный файл.</param>
        /// <exception cref="InvalidInputFileException">Входные данные в файле не в поддерживаемом формате.</exception>
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
