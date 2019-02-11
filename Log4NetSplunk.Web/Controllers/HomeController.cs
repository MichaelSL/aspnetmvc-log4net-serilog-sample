using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Log4NetSplunk.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILog log = LogManager.GetLogger(nameof(HomeController));

        public ActionResult Index()
        {
            log.Info("Index");
            log.Debug(JsonConvert.SerializeObject(Request.Headers));
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            log.Info("About");
            log.Debug(JsonConvert.SerializeObject(Request.Headers));
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            log.Info("Contact");
            log.Debug(JsonConvert.SerializeObject(Request.Headers));
            return View();
        }
    }
}