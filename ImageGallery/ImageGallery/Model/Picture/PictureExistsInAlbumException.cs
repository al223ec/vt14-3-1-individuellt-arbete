using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageGallery.Model
{
    public class PictureExistsInAlbumException : Exception
    {
        public PictureExistsInAlbumException()
        { }
        public PictureExistsInAlbumException(string message)
            : base(message)
        { }
        public PictureExistsInAlbumException(string message, Exception inner)
            : base(message, inner)
        { }
    }
}