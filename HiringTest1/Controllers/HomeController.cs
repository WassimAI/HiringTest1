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
            note.CreatedAt = DateTime.Now;

            db.Notes.Add(note);
            db.SaveChanges();

            return PartialView("_NoteThumbnailsPartial", db.Notes.ToArray().Select(x => new NoteVM(x)).ToList());
        }

        [HttpPost]
        // Home/DeleteNote/1
        public PartialViewResult DeleteNote(int id)
        {
            Note noteToDelete = db.Notes.Where(x => x.Id.Equals(id)).FirstOrDefault();

            db.Notes.Remove(noteToDelete);
            db.SaveChanges();

            return PartialView("_NoteThumbnailsPartial", db.Notes.ToArray().Select(x => new NoteVM(x)).ToList());
        }

        public ActionResult EditNote(int id)
        {
            Note note = db.Notes.Where(x => x.Id.Equals(id)).FirstOrDefault();

            var result = new { Title = note.Title, Text = note.Text, ColorId = note.ColorId };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void EditNote(NoteVM model)
        {
            Note noteToEdit = db.Notes.Where(x => x.Id.Equals(model.Id)).FirstOrDefault();

            noteToEdit.Title = model.Title;
            noteToEdit.Text = model.Text;
            noteToEdit.ColorId = model.ColorId;
            noteToEdit.CreatedAt = DateTime.Now;

            db.SaveChanges();
        }


    }
}