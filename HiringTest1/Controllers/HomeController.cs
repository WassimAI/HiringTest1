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
            var listOfColors = db.Colors.ToList();

            ViewBag.ColorList = new SelectList(listOfColors, "Id", "Name");

            return View();
        }

        public void AddNote(NoteVM model)
        {
            //Adding note code goes here
        }


    }
}