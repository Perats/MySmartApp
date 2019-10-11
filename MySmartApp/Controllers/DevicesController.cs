﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MySmartApp.Models;

namespace MySmartApp.Controllers
{
    public class DevicesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DevicesViewModels
        public ActionResult Index()
        {
            return View(db.DevicesViewModels.ToList());
        }

        // GET: DevicesViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var devices = db.DevicesViewModels.Where(i => i.Id == id).ToList();
            if (devices == null)
            {
                return HttpNotFound();
            }
            var model = new HomeModel();
            model.Devices = devices;
            model.Rooms = db.Rooms.ToList();
            var schedules = db.Schedules.ToList();
            model.Schedules = schedules.Where(i => i.DeviceName == devices[0].DeviceName).ToList();
            return View(model);
        }

        // GET: DevicesViewModels/Create
        public ActionResult Create()
        {
            var model = new HomeModel();
            model.Devices = db.DevicesViewModels.ToList();
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
        public ActionResult Create(DevicesViewModel devicesViewModel)
        {
            if (ModelState.IsValid)
            {
                var room = db.Rooms.Where(_ => _.Name == devicesViewModel.Rooms).ToList();
                if (room != null)
                {
                    devicesViewModel.LastPinDate = DateTime.Now;
                    devicesViewModel.RoomId = room[0].Id;
                    db.DevicesViewModels.Add(devicesViewModel);
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
            DevicesViewModel devicesViewModel = db.DevicesViewModels.Find(id);
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
        public ActionResult Edit([Bind(Include = "Id,DeviceName,LastPinDate,DeviceStatus")] DevicesViewModel devicesViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(devicesViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(devicesViewModel);
        }

        // GET: DevicesViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DevicesViewModel devicesViewModel = db.DevicesViewModels.Find(id);
            if (devicesViewModel == null)
            {
                return HttpNotFound();
            }
            return View(devicesViewModel);
        }

        // POST: DevicesViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DevicesViewModel devicesViewModel = db.DevicesViewModels.Find(id);
            db.DevicesViewModels.Remove(devicesViewModel);
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
