using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HiringTest1.Models.Data
{
    [Table("Note")]
    public class Note
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }
        public int ColorId { get; set; }
    }
}