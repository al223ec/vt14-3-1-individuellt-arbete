using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ImageGallery.Model
{
    public class Category
    {
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Kategorin måste ha ett värde")]
        [StringLength(35, ErrorMessage = "Kategorin får som mest innehålla 35 tecken")]
        public string Value { get; set; }
    }
}