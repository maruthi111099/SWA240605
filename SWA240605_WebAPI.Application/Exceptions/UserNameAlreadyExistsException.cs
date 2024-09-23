using System;

namespace SWA240605_WebAPI.Application.Exceptions
{
    public class UserNameAlreadyExistsException : Exception
    {
        public UserNameAlreadyExistsException() : base() { }

        public UserNameAlreadyExistsException(string message) : base(message) { }
    }
}
