using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace PruebaLibreria.Controllers
{
    [RoutePrefix("api/uploads")]
    public class UploadController : ApiController
    {
        private DTO_Autor DTO = new DTO_Autor();
        private string pathProject = System.AppContext.BaseDirectory;

        [HttpGet]
        [Route("img")]
        public HttpResponseMessage getImg(String imageName)
        {
            string path = pathProject + "/images/" + imageName;
            if (File.Exists(path))
            {
                byte[] b = System.IO.File.ReadAllBytes(path);

                MemoryStream ms = new MemoryStream(b);
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StreamContent(ms);
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpg");
                return response;
            }
            else
            {
                path = pathProject + "/images/no-img.jpg";
                byte[] b = System.IO.File.ReadAllBytes(path);

                MemoryStream ms = new MemoryStream(b);
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StreamContent(ms);
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpg");
                return response;
            }
        }


        [HttpPut]
        [Route("img")]
        public Models.Response putImg(String name)
        {
            Models.Response resp = new Models.Response();
            try
            {
                HttpPostedFile postedFile = HttpContext.Current.Request.Files[0];
                string fileName = name;
                string pathFile = pathProject + "/images/" + fileName;
                if (!File.Exists(pathFile))
                {
                    postedFile.SaveAs(pathFile);
                }
                resp.ok = "Img insert";
                return resp;
            }
            catch (Exception e)
            {
                resp.error = "Img insert failed";
                return resp;
            }
        }
    }
}