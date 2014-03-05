using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageGallery.Model
{
    public class AlbumPicture
    {
        public Album Album { get; set; }
        public Picture Picture { get; set; }

        public DateTime Date { get; set; }
    }
}