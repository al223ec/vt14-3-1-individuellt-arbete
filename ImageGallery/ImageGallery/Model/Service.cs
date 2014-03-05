using ImageGallery.Model.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageGallery.Model
{
    public class Service
    {
        private PictureDAL _pictureDAL;
        public PictureDAL PictureDAL { get { return _pictureDAL ?? (_pictureDAL = new PictureDAL()); } }

        private AlbumDAL _albumDAL;
        public AlbumDAL AlbumDAL { get { return _albumDAL ?? (_albumDAL = new AlbumDAL()); } }

        private CategoryDAL _categoryDAL;
        public CategoryDAL CategoryDAL { get { return _categoryDAL ?? (_categoryDAL = new CategoryDAL()); } }

        public IEnumerable<Picture> GetAllPictures()
        {
            return PictureDAL.GetAllPictures();
        }
        public IEnumerable<Picture> GetAllPicturesFromAlbum(int albumID)
        {
            return PictureDAL.GetAllPicturesFromAlbum(albumID);
        }
        public IEnumerable<Album> GetAllAlbums()
        {
            return AlbumDAL.GetAllAlbums();
        }

        public IEnumerable<Category> GetAllCategorys()
        {
            var allCategorys = HttpContext.Current.Cache["Categorys"] as IEnumerable<Category>; //Cahcar denna kommer inte uppdateras
            if (allCategorys == null)
            {
                allCategorys = CategoryDAL.GetAllCategorys();
                HttpContext.Current.Cache.Insert("Categorys", allCategorys, null, DateTime.Now.AddMinutes(10), TimeSpan.Zero); //tio min sen slängs cachen
            }
            return allCategorys;
        }
    }
}