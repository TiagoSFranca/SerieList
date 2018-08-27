using System;
using System.Collections.Generic;

namespace SerieList.Extras.Util
{
    public class Response<TEntity> where TEntity : class
    {
        public bool Success { get; set; }
        public string Method { get; set; }
        public string Message { get; set; }
        public ResponseException Exception { get; set; }

        public Response(string method)
        {
            Method = method;
        }

        public Response()
        {
        }

    }

    public class ResponseException
    {
        public string ErrorMessage { get; }
        public string StackTrace { get; }
        public string TypeError { get; }

        public ResponseException(Exception e)
        {
            ErrorMessage = e.Message;
            StackTrace = e.StackTrace;
            TypeError = e.GetType().ToString();
        }
    }

    public class ResponseSingleResult<TEntity> : Response<TEntity> where TEntity : class
    {
        public ResponseSingleResult(string method) : base(method)
        {
        }

        public ResponseSingleResult()
        {
        }

        public TEntity Result { get; set; }
    }

    public class ResponseMultipleResult<TEntity> : Response<TEntity> where TEntity : class
    {
        public ResponseMultipleResult(string method) : base(method)
        {
        }

        public ResponseMultipleResult()
        {
        }

        public IEnumerable<TEntity> Results { get; set; }
    }

    public class ResponseSearchResult<TEntity> : Response<TEntity> where TEntity : class
    {
        public ResponseSearchResult(string method) : base(method)
        {
        }
        
        public PagingResultSearchModel<TEntity> ResultPaged { get; set; }
    }

    public class PagingResultSearchModel<TEntity>
        where TEntity : class
    {
        public IEnumerable<TEntity> Items { get; set; }
        public int ActualPage { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
    }

}
