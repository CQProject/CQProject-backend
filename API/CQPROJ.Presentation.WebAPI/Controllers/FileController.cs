using CQPROJ.Business.Entities.IAccount;
using CQPROJ.Business.Queries;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace CQPROJ.Presentation.WebAPI.Controllers
{
    public class FileController : ApiController
    {
        //GET filedowload/:filename
        [HttpGet]
        [Route("download/image/{*filename}")]
        public Object DownloadImage(string filename)
        {
            try
            {
                Payload payload = BAccount.ConfirmToken(this.Request);

                if (payload == null)
                {
                    return new { result = false, info = "Não autorizado." };
                }

                var fileFolder = HttpContext.Current.Server.MapPath("~/Files/img");
                var filePath = Path.Combine(fileFolder, filename);

                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
                var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

                result.Content = new StreamContent(stream);

                result.Content.Headers.ContentType = new MediaTypeHeaderValue(MimeMapping.GetMimeMapping(filename));
                return result;
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.ServiceUnavailable);
            }
        }

        //GET filedowload/:filename
        [HttpGet]
        [Route("download/doc/{*filename}")]
        public Object DownloadFile(string filename)
        {
            try
            {
                Payload payload = BAccount.ConfirmToken(this.Request);

                if (payload == null)
                {
                    return new { result = false, info = "Não autorizado." };
                }

                var fileFolder = HttpContext.Current.Server.MapPath("~/Files/doc");
                var filePath = Path.Combine(fileFolder, filename);

                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
                var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                result.Content = new StreamContent(stream);
                result.Content.Headers.ContentType = new MediaTypeHeaderValue(MimeMapping.GetMimeMapping(filename));
                return result;
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.ServiceUnavailable);
            }
        }


        //POST /upload/image
        [HttpPost]
        [Route("upload/image")]
        public Object UploadImage()
        {
            try
            {
                Payload payload = BAccount.ConfirmToken(this.Request);

                if (payload == null)
                {
                    return new { result = false, info = "Não autorizado." };
                }

                if (HttpContext.Current.Request.Files.Count > 0)
                {
                    var image = HttpContext.Current.Request.Files["image"];

                    if (image != null && image.ContentType.Contains("image/"))
                    {
                        var fileFolder = HttpContext.Current.Server.MapPath("~/Files/img");
                        var fileName = Path.GetFileName(Guid.NewGuid() + "." + image.FileName);
                        var filePath = Path.Combine(fileFolder, fileName);
                        image.SaveAs(filePath);

                        return new { result = true, data = fileName };
                    }
                    return new { result = false, info = "Key inválida ou formato inaceitável." };

                }
                return new { result = false, info = "Não submeteu nenhuma imagem" };
            }
            catch (Exception)
            {
                return new { result = false, info = "Não foi possivel proceder ao upload." };
            }
        }

        //POST /upload/image
        [HttpPost]
        [Route("upload/doc")]
        public Object UploadFile()
        {
            try
            {
                Payload payload = BAccount.ConfirmToken(this.Request);

                if (payload == null || payload.rol.Contains(1) || payload.rol.Contains(4) || payload.rol.Contains(5))
                {
                    return new { result = false, info = "Não autorizado." };
                }

                if (HttpContext.Current.Request.Files.Count > 0)
                {
                    var file = HttpContext.Current.Request.Files["file"];
                    String[] acceptablefiles = new string[] {
                        "application/pdf",                                                              // .pdf
                        "application/zip",                                                              // .zip
                        "application/x-rar-compressed",                                                 // .rar
                        "application/msword",                                                           // .doc
                        "application/vnd.openxmlformats-officedocument.wordprocessingml.document",      // .docx
                        "application/vnd.ms-powerpoint",                                                // .ppt
                        "application/vnd.openxmlformats-officedocument.presentationml.presentation",    // .pptx
                        "application/vnd.ms-excel",                                                     // .xls
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",            // .xlsx
                        "application/vnd.oasis.opendocument.text",                                      // .odt
                        "application/vnd.oasis.opendocument.presentation",                              // .odp
                        "application/vnd.oasis.opendocument.spreadsheet",                               // .ods
                        "video/x-msvideo",                                                              // .avi
                        "video/mpeg",                                                                   // .mpeg
                        "video/mp4",                                                                    // .mp4
                        "audio/x-wav",                                                                  // .wav
                        "audio/mpeg",                                                                   // .mpega / .mp3
                        "audio/mp3"                                                                     // .mp3
                    };
                    Debug.WriteLine(file.ContentType);

                    if (file != null && acceptablefiles.Contains(file.ContentType))
                    {
                        var fileFolder = HttpContext.Current.Server.MapPath("~/Files/doc");
                        var fileName = Path.GetFileName(Guid.NewGuid() + "." + file.FileName);
                        var filePath = Path.Combine(fileFolder, fileName);
                        file.SaveAs(filePath);

                        return new { result = true, data = fileName };
                    }
                    return new { result = false, info = "Key inválida ou formato inaceitável." };

                }
                return new { result = false, info = "Não submeteu nenhum documento." };
            }
            catch (Exception)
            {
                return new { result = false, info = "Não foi possivel proceder ao upload." };
            }
        }

    }
}