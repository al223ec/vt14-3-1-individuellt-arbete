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
        public abstract string Name { get; set; } //Ska jag spara med filändelse eller ha en till kolumn där man sparar filändelsen??
        public abstract string Extension { get; set; }
        public Image Picture { get; set; }

        public string GetTumbFileName
        {
            get { return string.Format("{0}{1}{2}", Name, "_thumb", Extension); }
        }
        public string GetTumbFilePath
        {
            get { return string.Format("{0}{1}{2}{3}", FILEPATH, Name, "_thumb", Extension); }
        }

        public string GetImagePath
        {
            get { return string.Format("{0}{1}{2}", FILEPATH, Name, Extension); }
        }
    }
}