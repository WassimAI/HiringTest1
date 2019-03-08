using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HiringTest1.Models;
using HiringTest1.Models.Data;
using HiringTest1.Models.ViewModels;

namespace HiringTest1.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.ColorId = new SelectList(db.Colors, "Id", "Name");

            var model = new NoteVM();

            return View(model);
        }

        public ActionResult AddNote()
        {
            var model = new NoteVM();

            ViewBag.ColorId = new SelectList(db.Colors, "Id", "Name");
            
            return View(model);
        }
    }
}