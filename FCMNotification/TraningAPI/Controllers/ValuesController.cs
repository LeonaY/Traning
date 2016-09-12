using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace TraningAPI.Controllers
{
    public class ValuesController : ApiController
    {
        
        [HttpGet]
        public List<JsonResult> GetReactJson()
        {
            //JsonList jsonList = new JsonList();
            //jsonList.result = true;
            //jsonList.JsonResultList = new List<JsonResult>();
            List<JsonResult> jsonList = new List<JsonResult>();

            jsonList.Add(new JsonResult { id = "1", author = "Pete Hunt", text = "This is one comment" });
            jsonList.Add(new JsonResult { id = "2", author = "Jordan Walke", text = "This is *another* comment888" });
            Newtonsoft.Json.JsonConvert.SerializeObject(jsonList).ToString();
            return jsonList;
        }
        
    }
    public class JsonList
    {
        public bool result { get; set; }
        public List<JsonResult> JsonResultList { get; set; }
    }

    public class JsonResult
    {
        public string id { get; set; }
        public string author { get; set; }
        public string text { get; set; }
    }
}
