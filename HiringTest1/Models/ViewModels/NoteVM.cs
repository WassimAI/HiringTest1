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
        public NoteVM()
        {

        }

        public NoteVM(Note row)
        {
            Id = row.Id;
            Title = row.Title;
            Text = row.Text;
            ColorId = row.ColorId;
            Date = row.Date;
        }

        [Required]
        public int Id { get; set; }
        [StringLength(50, ErrorMessage ="The title cannot be more than 50 characters.")]
        public string Title { get; set; }
        [StringLength(512, ErrorMessage ="You have exceeded the maximum allowed characters.")]
        public string Text { get; set; }
        public int ColorId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

    }
}