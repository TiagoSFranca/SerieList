using System;

namespace SerieList.Infra.Data.CrossCutting.Exceptions.AppServiceException
{
    public class AppServiceException : Exception
    {
        public AppServiceException(string message) : base(message)
        {
        }
    }
}
