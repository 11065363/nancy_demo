using Nancy;
using NancyDemo1.Model;
using Nancy.ModelBinding;//数据绑定，多数据提交
using System.IO;

namespace NancyDemo1.Modules
{
    public class IndexModule : NancyModule
    {
        
        public IndexModule(IRootPathProvider pathProvider)//:base("product")
        {
            var uploadDirectory = Path.Combine(pathProvider.GetRootPath(), "Content", "uploads");
            //Before += ctx => {
            //    int i = 1;
            //    return "22";//null 不做处理
            //};
            Get["/"] = _ => View["index2"];
            Get["/up2"] = _ => View["indexup"];
            Post["/logic"] = _ =>
            {
                var t = Request.Files;
                foreach (var file in Request.Files)
                                     {
                                         var filename = Path.Combine(uploadDirectory, file.Name);
                                         using (FileStream fileStream = new FileStream(filename, FileMode.Create))
                                             {
                                                 file.Value.CopyTo(fileStream);
                                             }
                                     }
                return "22";
            };
            Get["/aa.jpg"] = _ =>
            {
                // return Response.AsFile("Content/uploads/b.jpg");
                return Response.AsFile("Content/uploads/aa.jpg");
            };
            Get["/down/{name}"] = _ =>
            {
                                 string fileName = _.name;
                                 var relatePath = @"Content\uploads\" + fileName;
                                 return Response.AsFile(relatePath);
            };
            Get["/one"] = _ => View["one"];
            Get["/two"] = _ => View["two"];
            Post["/three"] = _ => {
                Student stu = this.Bind();
                Student stu2 = new Student();
                return Response.AsJson(stu) ;
                
            };
            Get["/pic"] = _ =>
            {
                return "";
            };
            Get["/four"] = _ => View["four"];
            // Get["/"] = parameters => "Hello World";
            Post["/login", (ctx) => ctx.Request.Form.remember] = _ =>
                 {
                     return "true";
                 };
            Post["/login", (ctx) => !ctx.Request.Form.remember] = _ =>
            {
                return "Handling code when remember is false!";
            };
            Get["/intConstraint/{value:int}"] = _ => "Value " + _.value + " is an integer.";//路由约束
        }

        
    }
}