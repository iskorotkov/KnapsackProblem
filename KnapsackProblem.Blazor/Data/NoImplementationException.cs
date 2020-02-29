using System;

namespace KnapsackProblem.BlazorApp.Data
{
    /// <summary>
    /// Предоставленная DLL не содержит ни одного экспортированного класса алгоритма с публичным конструктором по умолчанию.
    /// </summary>
    public class NoImplementationException : ApplicationException
    {
        public NoImplementationException() { }
        public NoImplementationException(string message) : base(message) { }
        public NoImplementationException(string message, Exception innerException) : base(message, innerException) { }
    }
}
