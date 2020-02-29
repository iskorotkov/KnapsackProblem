using System;

namespace KnapsackProblem.BlazorApp.Data
{
    public class InvalidInputFileException : ApplicationException
    {
        public InvalidInputFileException() { }
        public InvalidInputFileException(string message) : base(message) { }
        public InvalidInputFileException(string message, Exception innerException) : base(message, innerException) { }
    }
}
