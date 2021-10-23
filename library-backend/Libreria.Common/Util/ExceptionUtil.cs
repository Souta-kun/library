using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Common.Extension
{
    public class ExceptionUtil
    {
        private static ExceptionUtil _instance;

        public static ExceptionUtil GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ExceptionUtil();
            }
            return _instance;
        }

        public void Get(string error, string stackTrace)
        {
            throw new HttpResponseException()
            {
                Value = new Error {
                    Mensaje = error,
                    StackTrace = stackTrace
                }
            };
        }
    }
}
