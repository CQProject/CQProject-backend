using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace CQPROJ.Presentation.WebAPI.Controllers
{
    public class FileUploadController : ApiController
    {
        //POST fileupload/
        [HttpPost]
        [Route("fileupload")]
        public Object UploadFile()
        {
            var fileName = "";
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                // Get the uploaded image from the Files collection
                var httpPostedFile = HttpContext.Current.Request.Files["file"];
                
                if (httpPostedFile != null)
                {
                    // Validate the uploaded image(optional)

                    // Get the complete file path
                    var fileFolder = HttpContext.Current.Server.MapPath("~/UploadedFiles").Replace("CQPROJ.Presentation.WebAPI", "CQPROJ.Business");
                    fileName = Path.GetFileName(Guid.NewGuid() + httpPostedFile.FileName);
                    var fileSavePath = Path.Combine(fileFolder, fileName);

                    // Save the uploaded file to "UploadedFiles" folder
                    httpPostedFile.SaveAs(fileSavePath);
                    
                }
                
            }

            return new { result = true, data = fileName };
        }

    }
}