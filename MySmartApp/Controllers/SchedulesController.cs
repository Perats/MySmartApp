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
    public class SchedulesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Schedules
        public ActionResult Index()
        {
            return View(db.Schedules.ToList());
        }

        // GET: Schedules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = db.Schedules.Find(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
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
            List<string> devices = new List<string>();
            foreach (var item in model.Devices)
            {
                devices.Add(item.DeviceName);
            }
            ViewBag.Devices = devices;
            return View(model);
        }

        // GET: Schedules/Create
        public ActionResult Create()
        {
            var model = new HomeModel();
            model.Devices = db.Devices.ToList();
            model.Rooms = db.Rooms.ToList();
            model.Schedules = db.Schedules.ToList();
            List<string> devices = new List<string>();
            foreach (var item in model.Devices)
            {
                devices.Add(item.DeviceName);
            }
            ViewBag.Devices = devices;
            return View(model);
        }

        // POST: Schedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DeviceId,DeviceName,ScheduleName,StartDate,EndDate,DeviceStatus,IsActive")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                var deviceId = db.Devices.Where(_ => _.DeviceName == schedule.DeviceName).ToList();
                if (deviceId != null)
                {
                    schedule.DeviceId = deviceId[0].Id;
                    db.Schedules.Add(schedule);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
               
            }

            return View();
        }

        // GET: Schedules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = db.Schedules.Find(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        // POST: Schedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DeviceId,DeviceName,ScheduleName,StartDate,EndDate,DeviceStatus,IsActive")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(schedule);
        }

        // GET: Schedules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = db.Schedules.Find(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        // POST: Schedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Schedule schedule = db.Schedules.Find(id);
            db.Schedules.Remove(schedule);
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
