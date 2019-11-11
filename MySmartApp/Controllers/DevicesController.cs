using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using MySmartApp.Models;

namespace MySmartApp.Controllers
{
    public class DevicesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private MongoDBContext dbContext = new MongoDBContext();

        // GET: DevicesViewModels
        public ActionResult Index()
        {
            return View(db.Devices.ToList());
        }

        // GET: DevicesViewModels/Details/5
        public ActionResult Details(int? id, string data = null)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var devices = db.Devices.Where(i => i.Id == id).ToList();
           if (devices == null)
            {
                return HttpNotFound();
            }
            var model = new HomeModel();
            model.Devices = devices;
            model.Rooms = db.Rooms.ToList();
            var schedules = db.Schedules.ToList();
            var list = dbContext.DeviceCollection.Find(new BsonDocument()).ToList();
            var led = list[2].Values.ToList();
            devices[0].DeviceStatus = (DeviceStatus)led[2].ToInt32();
            ViewBag.Status = devices[0].DeviceStatus == 0 ? "Turn Off" : "Turn On";
            ViewBag.Value = devices[0].DeviceStatus == 0 ? 1 : 0;
            model.Schedules = schedules.Where(i => i.DeviceName == devices[0].DeviceName).ToList();
            if (data != null)
            {
                ViewBag.Success = "Success";
                return View(model);
            }
            return View(model);
        }

        // GET: DevicesViewModels/Create
        public ActionResult Create()
        {
            var model = new HomeModel();
            model.Devices = db.Devices.ToList();
            model.Rooms = db.Rooms.ToList();
            model.Schedules = db.Schedules.ToList();
            var rooms = new List<string>();
            foreach (var item in model.Rooms)
            {
                rooms.Add(item.Name);
            }
            ViewBag.Rooms = rooms;
            return View(model);
        }

        // POST: DevicesViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(Devices devicesViewModel)
        {
            if (ModelState.IsValid)
            {
                var room = db.Rooms.Where(_ => _.Name == devicesViewModel.Rooms).ToList();
                if (room.Count != 0)
                {
                    devicesViewModel.LastPinDate = DateTime.Now;
                    devicesViewModel.RoomId = room[0].Id;
                    db.Devices.Add(devicesViewModel);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(devicesViewModel);
        }

        // GET: DevicesViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Devices devicesViewModel = db.Devices.Find(id);
            if (devicesViewModel == null)
            {
                return HttpNotFound();
            }
            return View(devicesViewModel);
        }

        // POST: DevicesViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DeviceName,LastPinDate,DeviceStatus")] Devices devicesViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(devicesViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(devicesViewModel);
        }

        public async Task<ActionResult> LampAction(int? status, int id)
        {
            var mqttClient = new MqttFactory().CreateMqttClient();
            var options = new MqttClientOptionsBuilder()
                   .WithClientId("MvcApp")
                   .WithTcpServer("localhost", 1884)
                   .WithKeepAlivePeriod(new TimeSpan(1, 0, 0))
                   .Build();

            try
            {
                await mqttClient.ConnectAsync(options, CancellationToken.None);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            if (mqttClient.IsConnected)
            {
                await mqttClient.SubscribeAsync(new TopicFilterBuilder().WithTopic("device/led").Build());
                await mqttClient.PublishAsync("device/led", Encoding.UTF8.GetBytes(status.ToString()));
            }
            await Task.Delay(1500);
            var listMongo = dbContext.DeviceCollection.Find(new BsonDocument()).ToList();
            var led = listMongo[2].Values.ToList();
            if (led[3].ToString() == "success")
            {
                var filter = Builders<BsonDocument>.Filter.Eq("Name", "Light");
                var update = Builders<BsonDocument>.Update.Set("Value", status);
                var result = await dbContext.DeviceCollection.UpdateOneAsync(filter, update);
                return RedirectToAction("Details", "Devices", new { id });
            }

            return Redirect("");
        }

        // GET: DevicesViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Devices devicesViewModel = db.Devices.Find(id);
            if (devicesViewModel == null)
            {
                return HttpNotFound();
            }
            db.Devices.Remove(devicesViewModel);
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }

        // POST: DevicesViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Devices devicesViewModel = db.Devices.Find(id);
            db.Devices.Remove(devicesViewModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
