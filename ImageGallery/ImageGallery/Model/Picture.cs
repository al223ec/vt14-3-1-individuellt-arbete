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

        [Required(ErrorMessage = "Bilden måste ha ett namn")]
        [StringLength(35, ErrorMessage = "Bildnamnet kan som mest bestå av 35 tecken.")]
        public override string Name { get; set; }
        
        [Required]
        public int CategoryID { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}