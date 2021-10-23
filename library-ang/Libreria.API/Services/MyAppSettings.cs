using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libreria.API.Services
{
    public class MyAppSettings
    {
        public const string SectionName = "ConnectionStrings";

        public string SQLServerConnection { get; set; }
    }
}
