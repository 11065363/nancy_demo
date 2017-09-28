using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NancyDemo1.Logic
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpPostedFile file = context.Request.Files[0];
            String fileName = System.IO.Path.GetFileName(file.FileName);
            file.SaveAs(context.Server.MapPath("~/") + fileName);
            context.Response.Write("OK");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}