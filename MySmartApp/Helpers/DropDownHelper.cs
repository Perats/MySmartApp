using MySmartApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySmartApp.Helpers
{
    public class DropDownHelper
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public IEnumerable<Rooms> GetAllCategories()
        {
            var categories = db.Rooms.ToList();
            return categories.Select( x => new Rooms { Name = x.Name, Id = x.Id } );
        }
    }
}