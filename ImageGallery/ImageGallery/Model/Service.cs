using ImageGallery.Model.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageGallery.Model
{
    public class Service
    {
        private ImageGalleryDAL _imageGalleryDAL;
        public ImageGalleryDAL ImageGalleryDAL { get { return _imageGalleryDAL ?? (_imageGalleryDAL = new ImageGalleryDAL()); } }

        public IEnumerable<Picture> GetPictures()
        {
            return ImageGalleryDAL.GetAllPictures(); 
        }
    }
}