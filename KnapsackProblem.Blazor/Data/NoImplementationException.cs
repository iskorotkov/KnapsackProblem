using System;

namespace KnapsackProblem.BlazorApp.Data
{
    public class NoImplementationException : ApplicationException
    {
        public NoImplementationException() { }
        public NoImplementationException(string message) : base(message) { }
        public NoImplementationException(string message, Exception innerException) : base(message, innerException) { }
    }
}
