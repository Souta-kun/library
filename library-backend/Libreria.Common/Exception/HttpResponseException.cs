using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Common
{
    public class HttpResponseException : Exception
    {
        public int Status { get; set; } = 500;
        public object Value { get; set; }
    }

    public class Error
    {
        public string Mensaje { get; set; }
        public string StackTrace { get; set; }
    }
}
