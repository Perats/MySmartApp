using MongoDB.Bson;
using MongoDB.Driver;
using MySmartApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySmartApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private MongoDBContext dbContext = new MongoDBContext();
        public ActionResult Index()
        {
            var model = new HomeModel();
            model.Devices = db.Devices.ToList();
            model.Rooms = db.Rooms.ToList();
            model.Schedules = db.Schedules.ToList();
            var list = dbContext.DeviceCollection.Find(new BsonDocument()).ToList();
            var hum = list[0].Values.ToList();
            var temp = list[1].Values.ToList();
            var led = list[2].Values.ToList();
            model.Devices[0].Temperature = temp[2].ToString();
            model.Devices[0].DeviceStatus = (DeviceStatus)led[2].ToInt32();
            model.Devices[0].Humidity = hum[2].ToString();
            return View(model);
        }

        [HttpGet]
        public PartialViewResult TestDialog()
        {
            return PartialView();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}