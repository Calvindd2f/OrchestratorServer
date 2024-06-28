using System;

namespace OrchestratorServer.Exceptions
{
    public class ServiceException : Exception
    {
        public ServiceException(string message) : base(message) { }
    }
}
