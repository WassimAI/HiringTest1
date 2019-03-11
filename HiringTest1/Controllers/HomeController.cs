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
            var model = new List<NoteVM>();

            model = db.Notes.ToArray().Select(x => new NoteVM(x)).ToList();

            return View(model);
        }

        [HttpPost]
        // /Home/addNoteAjax
        public PartialViewResult addNote(NoteVM model)
        {
            //Adding note code goes here
            Note note = new Note();

            note.Title = model.Title;
            note.Text = model.Text;
            note.ColorId = model.ColorId;
            note.Date = DateTime.Now;

            db.Notes.Add(note);
            db.SaveChanges();

            return PartialView("_NoteThumbnailsPartial", db.Notes.ToArray().Select(x => new NoteVM(x)).ToList());
        }


    }
}