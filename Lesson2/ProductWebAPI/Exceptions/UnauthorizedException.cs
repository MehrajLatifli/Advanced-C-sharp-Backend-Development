﻿namespace ProductWebAPI.Exceptions
{
    public class UnauthorizedException : ApplicationException
    {
        public UnauthorizedException(string message) : base(message) { }
    }
}
