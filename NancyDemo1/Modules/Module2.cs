using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NancyDemo1.Modules
{
    public class Module2:NancyModule
    {
        public Module2():base("test")
        {
            Get["/"] = _ => View["four"];
        }
    }
}