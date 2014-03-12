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
        public abstract string PictureFileName { get; set; }
        public abstract string Extension { get; set; }/// Oklart

        public string GetTumbFileName
        {
            get { return string.Format("{0}{1}{2}", PictureFileName, "_thumb", Extension); }
        }
        public string GetTumbFilePath
        {
            get { return string.Format("{0}{1}{2}{3}", FILEPATH, PictureFileName, "_thumb", Extension); }
        }

        public string GetImagePath
        {
            get { return string.Format("{0}{1}{2}", FILEPATH, PictureFileName, Extension); }
        }
    }
}