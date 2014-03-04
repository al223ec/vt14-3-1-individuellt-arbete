using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ImageGallery.Model
{
    public abstract class PictureBase
    {
        public static readonly string saveFilePath;
        public abstract string Name { get; set; } //Ska jag spara med filändelse eller ha en till kolumn där man sparar filändelsen??

        public string GetTumbFileName{
            get { return string.Format("{0}{1}{2}", Path.GetFileNameWithoutExtension(Name), "_thumb", Path.GetExtension(Name)); }
        }
    }
}