﻿namespace ProductWebAPI.Exceptions
{
    public class ValidationException : ApplicationException
    {

        public IDictionary<string, string[]> Errors { get; }

        public ValidationException(string message) : base(message)
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(string message, IDictionary<string, string[]> errors) : base(message)
        {
            Errors = errors;
        }

    }
}
