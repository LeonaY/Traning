using DateCustomValidationExample.Models;
using FCMNotification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FCMNotification.Controllers
{
    public class CustomerValidateTraningController : Controller
    {
        // GET: CustomerValidateTraning
        public ActionResult Index()
        {
            return View();
        }
        // GET: CustomerValidateTraning
        [HttpPost]
        public ActionResult Index(Project input)
        {
            return View(input);
        }
    }
}