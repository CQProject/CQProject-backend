using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace CQPROJ.Presentation.WebAPI.Controllers
{
    public class FileUploadController : ApiController
    {
        //GET filedowload/:filename
        [HttpGet]
        [Route("filedownload/{*filename}")]
        public Object DownloadFile(string filename)
        {
            try
            {
                var fileFolder = HttpContext.Current.Server.MapPath("~/UploadedFiles").Replace("CQPROJ.Presentation.WebAPI", "CQPROJ.Business");
                var filePath = Path.Combine(fileFolder, filename);

                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
                var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                result.Content = new StreamContent(stream);
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                return result;
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.ServiceUnavailable);
            }
        }


        //POST fileupload/
        [HttpPost]
        [Route("fileupload")]
        public Object UploadFile()
        {
            try
            {
                if (HttpContext.Current.Request.Files.Count > 0)
                {
                    var file = HttpContext.Current.Request.Files["file"];

                    if (file != null)
                    {
                        var fileFolder = HttpContext.Current.Server.MapPath("~/UploadedFiles").Replace("CQPROJ.Presentation.WebAPI", "CQPROJ.Business");
                        var fileName = Path.GetFileName(Guid.NewGuid() + "." + file.FileName);
                        var filePath = Path.Combine(fileFolder, fileName);
                        file.SaveAs(filePath);

                        return new { result = true, data = fileName };
                    }
                    return new { result = false, info = "Não foi encontrado documento para a key." };

                }
                return new { result = false, info = "Não existe nenhum documento." };
            }
            catch (Exception)
            {
                return new { result = false, info = "Não foi possivel proceder ao upload." };
            }
        }
        
    }
}