using FCMNotification.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FCMNotification.Controllers
{
    public class reactController : Controller
    {
        // GET: react
        public async Task<ActionResult> Index()
        {
            return View();
        }

        public async Task<ActionResult> ADRepeter()
        {
            Rootobject rootobject = new Rootobject();
            using (var client = new HttpClient())
            {
                object postData = new object();

                postData = new
                {
                    GroupID = 1
                };
          
                StringContent content = new StringContent(JsonConvert.SerializeObject(postData, Formatting.Indented), Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.TryAddWithoutValidation("ValidateCode", "R5+2dFGmhnxtv3UkPL/GmkCOLXp+Qy0M");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.PostAsync("http://203.69.168.86/api/kanban/GetAdGroupSchedule", content);

                var responseString = await response.Content.ReadAsStringAsync();
                System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                rootobject = serializer.Deserialize<Rootobject>(responseString);
                rootobject.adGroup.AdSites.Select(x => x.AdType = 3);

                ViewBag.Response = rootobject.adGroup.AdSites.Where(x => x.AdType == 3);
            }
            return View(rootobject);
        }
    }
}