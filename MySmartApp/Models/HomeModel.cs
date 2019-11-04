using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySmartApp.Models
{
    public class HomeModel
    {
        public List<Devices> Devices { get; set; }
        public List<Rooms> Rooms { get; set; }
        public List<Schedule> Schedules { get; set; }
    }
}