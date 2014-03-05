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

        [Required(ErrorMessage = "Categorin måste ha ett värde")]
        public string Value { get; set; }
    }
}