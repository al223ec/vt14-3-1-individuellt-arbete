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

        private AlbumDAL _albumDAL;
        public AlbumDAL AlbumDAL { get { return _albumDAL ?? (_albumDAL = new AlbumDAL()); } }

        public IEnumerable<Picture> GetAllPictures()
        {
            return ImageGalleryDAL.GetAllPictures(); 
        }
        public IEnumerable<Picture> GetAllPicturesFromAlbum(int albumID)
        {
            return ImageGalleryDAL.GetAllPicturesFromAlbum(albumID);
        }
        public IEnumerable<Album> GetAllAlbums()
        {
            return AlbumDAL.GetAllAlbums();
        }
    }
}