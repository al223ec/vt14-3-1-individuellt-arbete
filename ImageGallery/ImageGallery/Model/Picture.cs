using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageGallery.Model
{
    public class Picture
    {
        public int PictureID { get; set; }
        public string Name { get; set; }
        public int CategoryID { get; set; }
        public DateTime Date { get; set; }
    }
}