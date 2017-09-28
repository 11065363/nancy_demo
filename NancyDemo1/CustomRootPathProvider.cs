using Nancy;
using System;

namespace NancyDemo1
{
    public class CustomRootPathProvider : IRootPathProvider
    {
        public string GetRootPath()
         {
             return AppDomain.CurrentDomain.GetData(".appPath").ToString(); 
         }
}
}