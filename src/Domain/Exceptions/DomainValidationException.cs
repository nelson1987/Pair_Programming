﻿namespace Pragma.Domain.Exceptions
{
    public class DomainValidationException : Exception
    {
        public DomainValidationException(string message) : base(message)
        {
        }
    }
}
