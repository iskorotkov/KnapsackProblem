using System;

namespace KnapsackProblem.BlazorApp.Data
{
    /// <summary>
    /// Файл не содержит входные данные в поддерживаемом формате.
    /// </summary>
    public class InvalidInputFileException : ApplicationException
    {
        public InvalidInputFileException() { }
        public InvalidInputFileException(string message) : base(message) { }
        public InvalidInputFileException(string message, Exception innerException) : base(message, innerException) { }
    }
}
