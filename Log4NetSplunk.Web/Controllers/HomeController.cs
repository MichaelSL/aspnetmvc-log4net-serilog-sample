using log4net;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Log4NetSplunk.Web.Controllers
{
    public class HomeController : Controller
    {
        private const bool WriteToLog4Net = false;

        private readonly ILog log = LogManager.GetLogger(nameof(HomeController));

        private static readonly Serilog.Core.Logger serilog =
            new LoggerConfiguration()
            .Enrich.FromLogContext()
            .Enrich.WithHttpRequestClientHostIP()
            .Enrich.WithHttpRequestId()
            .Enrich.WithHttpRequestType()
            .Enrich.WithMvcControllerName()
            .Enrich.WithMvcActionName()
            .MinimumLevel.Verbose()
            .WriteTo.Log4Net()
            .WriteTo.EventCollector("http://localhost:8088/services/collector", "5bd3c67e-da31-4c32-8f13-363a8987dea5")
            .CreateLogger();

        public ActionResult Index()
        {
            log.Info($"{nameof(Index)}");
            log.Debug(JsonConvert.SerializeObject(Request.Headers));
            serilog.Debug("{@Headers}", Request.Headers);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            log.Info($"{nameof(About)}");
            log.Debug(JsonConvert.SerializeObject(Request.Headers));
            serilog.Debug("{@Headers}", Request.Headers);
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            log.Info($"{nameof(Contact)}");
            log.Debug(JsonConvert.SerializeObject(Request.Headers));
            serilog.Debug("{@Headers}", Request.Headers);
            return View();
        }
    }
}