using System;

namespace SalesWebMvcASPCore.Services.Exceptions
{
    public class IntegrityException : ApplicationException
    {
        public IntegrityException (string message) : base(message)
        { }
    }
}
