using System;

namespace SerieList.Infra.Data.CrossCutting.Exceptions.ServiceException
{
    public class ServiceException : Exception
    {
        public ServiceException(string message) : base(message)
        {
        }
    }
}
