using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BTAS.API.Extensions
{
    public class ExceptionResponse
    {
        public string Type { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public bool Status { get; set; }
        public int StatusCode { get; set; }

        public ExceptionResponse(Exception ex)
        {
            Type = ex.GetType().Name;
            Message = ex.Message;
            Status = false;
            StackTrace = ex.ToString();
            StatusCode = 500;
            if (ex is HttpStatusException httpException)
            {
                //this.StatusCode = httpException.Status.ToString();
                this.StatusCode = (int)httpException.Status;
            }
        }
        public class HttpStatusException : Exception
        {
            public HttpStatusCode Status { get; set; }
            public HttpStatusException(HttpStatusCode code, string msg) : base(msg)
            {
                this.Status = code;
            }
        }
    }
}
