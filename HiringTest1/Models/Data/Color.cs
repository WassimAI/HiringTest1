﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HiringTest1.Models.Data
{
    [Table("Color")]
    public class Color
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}