using System;

namespace SalesWebMvcASPCore.Services.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string message) : base(message)
        { 
        }
    }
}
