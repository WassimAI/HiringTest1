using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HiringTest1.Models.Data;

namespace HiringTest1.Models.ViewModels
{
    public class NoteVM
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public NoteVM()
        {

        }

        public NoteVM(Note row)
        {
            Id = row.Id;
            Title = row.Title;
            Text = row.Text;
            ColorId = row.ColorId;
            CreatedAt = row.CreatedAt;
        }

        [Required]
        public int Id { get; set; }
        [StringLength(50, ErrorMessage ="The title cannot be more than 50 characters.")]
        public string Title { get; set; }
        [StringLength(512, ErrorMessage ="You have exceeded the maximum allowed characters.")]
        public string Text { get; set; }
        public string ShortText {
            get
            {
                if (Text.Length <= 20)
                    return Text;
                else
                    return Text.Substring(0, 20) + "...";
            }
        }
        public int ColorId { get; set; }

        public string ColorName { get { return db.Colors.Where(x => x.Id == ColorId).Select(x => x.Name).FirstOrDefault(); } }
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }

    }
}