using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageGallery.Model
{
    public class AlbumHavePicturesException : Exception
    {
        public AlbumHavePicturesException()
        { }
        public AlbumHavePicturesException(string message)
            : base(message)
        { }
        public AlbumHavePicturesException(string message, Exception inner)
            : base(message, inner)
        { }
    }
}