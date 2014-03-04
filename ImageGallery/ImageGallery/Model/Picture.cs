﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ImageGallery.Model
{
    public class Picture : PictureBase
    {
        public int PictureID { get; set; }
        
        [Required]
        public override string Name { get; set; }
        
        [Required]
        public int CategoryID { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}