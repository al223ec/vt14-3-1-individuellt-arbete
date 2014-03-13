using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ImageGallery.Model
{
    public abstract class PictureBase
    {
        protected static readonly string FILEPATH = "~/Content/Pictures/";
        protected static readonly Regex ApprovedExtensions = new Regex("(.jpg|.gif|.png)", RegexOptions.IgnoreCase);

        public abstract string PictureFileName { get; set; }

        public string GetTumbFileName
        {
            get { return string.Format("{0}{1}{2}", Path.GetFileNameWithoutExtension(PictureFileName), "_thumb", Path.GetExtension(PictureFileName)); }
        }
        public string GetTumbFilePath
        {
            get { return string.Format("{0}{1}{2}{3}", FILEPATH, Path.GetFileNameWithoutExtension(PictureFileName), "_thumb", Path.GetExtension(PictureFileName)); }
        }

        public string GetImagePath
        {
            get { return string.Format("{0}{1}", FILEPATH, PictureFileName); }
        }
    }
}