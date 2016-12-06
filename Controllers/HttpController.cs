using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace HighCharts.Controllers
{
    public class HttpController : Controller
    {
        // GET: Http
        public ActionResult MyPostFunc()
        {
            using (var client = new HttpClient()) {
                client.DefaultRequestHeaders.ExpectContinue = false; 
                var pageRequestJson = new StringContent(System.IO.File.ReadAllText("request.json"));
                var response = client.PostAsync("https://PhantomJScloud.com/api/browser/v2/ak-gf2th-y3wns-xkbj7-hmh1x-2ga4b/", pageRequestJson).Result;
                var responseStream = response.Content.ReadAsStreamAsync().Result;
                using (var fileStream = new System.IO.FileStream("content.jpg", System.IO.FileMode.Create)) {
                    responseStream.CopyTo(fileStream);
                }
                Console.WriteLine("*** Headers, pay attention to those starting with 'pjsc-' ***");
                Console.WriteLine(response.Headers);
            }
            return View();
        }
    }
}