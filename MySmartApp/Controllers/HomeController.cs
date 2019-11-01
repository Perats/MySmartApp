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
            model.Devices = db.DevicesViewModels.ToList();
            model.Rooms = db.Rooms.ToList();
            model.Schedules = db.Schedules.ToList();
            var list = dbContext.DeviceCollection.Find(new BsonDocument()).ToList();
            //foreach (var item in devices)
            //{
            //    model = new DevicesViewModel
            //    {
            //        DeviceName = item.DeviceName,
            //        Id = item.Id,
            //        DeviceStatus = item.DeviceStatus,
            //        LastPinDate = item.LastPinDate,
            //        RoomType = item.RoomType
            //    };
            //}
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