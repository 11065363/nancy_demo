using Nancy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace NancyDemo1.Modules
{
    public class UpAndDown:NancyModule
    {
        public UpAndDown(IRootPathProvider pathProvider) :base("tt")
        {
            var uploadDirectory = Path.Combine(pathProvider.GetRootPath(), "Content", "uploads");

            Get["/"] = _ =>
            {
                return View["UpAndDown2"];
            };

            Post["/"] = _ =>
            {

                if (!Directory.Exists(uploadDirectory))
                {
                    Directory.CreateDirectory(uploadDirectory);
                }

                foreach (var file in Request.Files)
                {
                    var filename = Path.Combine(uploadDirectory, file.Name);
                    using (FileStream fileStream = new FileStream(filename, FileMode.Create))
                    {
                        file.Value.CopyTo(fileStream);
                    }
                }
                return Response.AsRedirect("/UpAndDown");
            };

            Get["/down/{name}"] = _ =>
            {
                string fileName = _.name;
                var relatePath = @"Content\uploads\" + fileName;
                return Response.AsFile(relatePath);
            };

            Get["/UpAndDown"] = _ =>
            {
                var folder = new DirectoryInfo(uploadDirectory);
                IList<string> files = new List<string>();
                foreach (var file in folder.GetFiles())
                {
                    files.Add(file.Name);
                }
                return View["UpAndDown", files];
            };
        }
    }
}
