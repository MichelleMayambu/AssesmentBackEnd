using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssesmentApi.Model
{
    public class Response
    {
        public bool ok { get; set; }
        public string msg { get; set; }
        public dynamic data { get; set; }
    }
  
}
