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
    public class NotificationController : Controller
    {
        NotificationModels models = new NotificationModels();

        // GET: Notification
        [HttpGet]
        public ActionResult Index()
        {
            models.IsByToken = true;
            return View(models);
        }

        [HttpPost]
        public async Task<ActionResult> Index(NotificationModels formModel)
        {
            using (var client = new HttpClient())
            {
                object postData = new object();

                if (formModel.IsByToken)
                {
                    //By Registration Token Notification
                    postData = new
                    {
                        notification = new
                        {
                            body = formModel.SendMsg,
                            title = formModel.SendTitle
                        },
                        to = formModel.RegistrationToken
                    };
                }
                else
                {
                    //By Topic Notification
                    postData = new
                    {
                        notification = new
                        {
                            body = formModel.SendMsg,
                            title = formModel.SendTitle
                        },
                        to = string.Format("/topics/{0}", formModel.Topics)
                    };
                }

                StringContent content = new StringContent(JsonConvert.SerializeObject(postData, Formatting.Indented), Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "key=" + formModel.Authorization);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.PostAsync("https://fcm.googleapis.com/fcm/send", content);

                var responseString = await response.Content.ReadAsStringAsync();
                models.SendResponse = responseString;
            }
            return View(models);
        }

        public ActionResult BatchAddTopic()
        {
            ViewBag.Title = "批次新增主題";
            return View(models);
        }
        [HttpPost]
        public async Task<ActionResult> BatchAddTopic(NotificationModels formModel)
        {
            using (var client = new HttpClient())
            {
                object postData = new object();
                List<string> token = new List<string>();
                if (!string.IsNullOrEmpty(formModel.RegistrationToken))
                {
                    foreach (var item in formModel.RegistrationToken.Split(','))
                    {
                        token.Add(item);
                    }
                }

                postData = new
                {
                    registration_tokens = token,
                    to = string.Format("/topics/{0}", formModel.Topics)
                };

                StringContent content = new StringContent(JsonConvert.SerializeObject(postData, Formatting.Indented), Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "key=" + formModel.Authorization);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.PostAsync("https://iid.googleapis.com/iid/v1:batchAdd", content);

                var responseString = await response.Content.ReadAsStringAsync();
                models.SendResponse = responseString;
            }
            return View(models);
        }


        public ActionResult BatchRemoveTopic()
        {
            ViewBag.Title = "批次刪除主題";
            return View(models);
        }
        [HttpPost]
        public async Task<ActionResult> BatchRemoveTopic(NotificationModels formModel)
        {
            using (var client = new HttpClient())
            {
                object postData = new object();
                List<string> token = new List<string>();
                if (!string.IsNullOrEmpty(formModel.RegistrationToken))
                {
                    foreach (var item in formModel.RegistrationToken.Split(','))
                    {
                        token.Add(item);
                    }
                }
                postData = new
                {
                    registration_tokens = token,
                    to = string.Format("/topics/{0}", formModel.Topics)
                };

                StringContent content = new StringContent(JsonConvert.SerializeObject(postData, Formatting.Indented), Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "key=" + formModel.Authorization);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.PostAsync("https://iid.googleapis.com/iid/v1:batchRemove", content);

                var responseString = await response.Content.ReadAsStringAsync();
                models.SendResponse = responseString;
            }
            return View(models);
        }

        public ActionResult GetTokenInfo()
        {
            return View(models);
        }

        [HttpPost]
        public async Task<ActionResult> GetTokenInfo(NotificationModels formModel)
        {
            using (var client = new HttpClient())
            {
                object postData = new object();
                string url = string.Format("https://iid.googleapis.com/iid/info/{0}?details=true", formModel.RegistrationToken);

                StringContent content = new StringContent(JsonConvert.SerializeObject(postData, Formatting.Indented), Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "key=" + formModel.Authorization);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.PostAsync(url, content);

                var responseString = await response.Content.ReadAsStringAsync();
                models.SendResponse = responseString;
            }
            return View(models);
        }


        public ActionResult GetConverAPNS()
        {
            return View(models);
        }

        [HttpPost]
        public async Task<ActionResult> GetConverAPNS(NotificationModels formModel)
        {
            using (var client = new HttpClient())
            {
                object postData = new object();
                List<string> token = new List<string>();
                if (!string.IsNullOrEmpty(formModel.RegistrationToken))
                {
                    foreach (var item in formModel.RegistrationToken.Split(','))
                    {
                        token.Add(item);
                    }
                }

                postData = new
                {
                    apns_tokens = token,
                    application = formModel.application,
                    sandbox = formModel.IsSandBox
                };

                StringContent content = new StringContent(JsonConvert.SerializeObject(postData, Formatting.Indented), Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "key=" + formModel.Authorization);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.PostAsync("https://iid.googleapis.com/iid/v1:batchImport", content);

                var responseString = await response.Content.ReadAsStringAsync();
                models.SendResponse = responseString;
            }
            return View(models);
        }
    }
}