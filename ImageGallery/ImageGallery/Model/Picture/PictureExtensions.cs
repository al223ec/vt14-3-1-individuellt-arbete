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
            return Path.Combine(PhysicalUploadedImagesPath, string.Format("{0}{1}", picture.PictureFileName, picture.Extension));
        }
    }
}