using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ImageGallery.Model
{
    public static class PictureExtensions
    {
        private static readonly Regex ApprovedExtensions = new Regex("(.jpg|.gif|.png)", RegexOptions.IgnoreCase); //, SanitizePath;
        public static readonly string PhysicalUploadedImagesPath = Path.Combine(AppDomain.CurrentDomain.GetData("APPBASE").ToString(), @"Content\Pictures");

        public static string GetPath(this Picture picture)
        {
            return PhysicalUploadedImagesPath; 
        } 
        public static string GetFullThumbnailPath(this Picture picture)
        {
            return Path.Combine(PhysicalUploadedImagesPath, picture.GetTumbFileName);
        }

        public static string GetFullImagePath(this Picture picture)
        {
            return Path.Combine(PhysicalUploadedImagesPath, string.Format("{0}{1}", picture.Name, picture.Extension));
        }


        //TODO: Ska jag placera dessa metoder här???, kan också lösa det genom en pictureHandler class. 
        public static Image GetThumbnail(this Picture picture)
        {
            //TODO: GetThumbnail
            throw new NotImplementedException();
        }

        public static bool CheckIfFileExists(this Picture picture)
        {
            //TODO: CheckIfFileExists
            throw new NotImplementedException();
        }

        public static void SaveImage(System.IO.Stream stream, string fileName)
        {
               //TODO: SaveImage
            throw new NotImplementedException();
        }

        public static bool CompareImage(Image image)
        {
            //TODO: //Hämta picture bilden och gämför?? Eller ladda upp på nytt?? 
            throw new NotImplementedException();

        }
    }
}