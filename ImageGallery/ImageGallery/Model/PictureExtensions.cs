using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace ImageGallery.Model
{
    public static class PictureExtensions
    {
        //TODO: Ska jag placera dessa metoder här???, kan också lösa det genom en pictureHandler class. 
        public static Image GetThumbnail(this Picture picture)
        {
            throw new NotImplementedException();
        }

        public static bool CheckIfFileExists(this Picture picture)
        {
            throw new NotImplementedException();
        }

        public static void SaveImage(System.IO.Stream stream, string fileName)
        {
            throw new NotImplementedException();
        }

    }
}