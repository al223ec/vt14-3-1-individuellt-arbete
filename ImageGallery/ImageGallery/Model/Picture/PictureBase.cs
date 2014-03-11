using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace ImageGallery.Model
{
    public abstract class PictureBase
    {
        public static readonly string FILEPATH = "~/Content/Pictures/";
        public abstract int PictureID { get; set; }
        public abstract string Extension { get; set; }
        public Image Picture { get; set; }

        public string GetTumbFileName
        {
            get { return string.Format("{0}{1}{2}", PictureID, "_thumb", Extension); }
        }
        public string GetTumbFilePath
        {
            get { return string.Format("{0}{1}{2}{3}", FILEPATH, PictureID, "_thumb", Extension); }
        }

        public string GetImagePath
        {
            get { return string.Format("{0}{1}{2}", FILEPATH, PictureID, Extension); }
        }
    }
}