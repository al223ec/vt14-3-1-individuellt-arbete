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

#region Getpictures
        public IEnumerable<Picture> GetAllPictures()
        {
            return PictureDAL.GetAllPictures();
        }
        public IEnumerable<Picture> GetAllPicturesFromAlbum(int albumID)
        {
            return PictureDAL.GetAllPicturesFromAlbum(albumID);
        }
        public Picture GetPicture(int pictureID)
        {
            return PictureDAL.GetPicture(pictureID);
        }
#endregion 
        public void AddPicture(Picture picture, int albumID) //Bör ta en array om jag ska uppdatera bilden till många album
        {
            //Kontroller objekt och albumIDt

            if (picture.PictureID == 0) //Ny bild
            {

            }
            else
            {
               PictureDAL.UpdatePicture(picture);
            }

           // PictureDAL.AddPicture(picture, albumID); 
            PictureDAL.AddPicture(picture);
            AlbumDAL.AddAlbumAndPicture(1,1); 
        }

        public void DeletePicture(int pictureID)
        {
            PictureDAL.DeletePicture(pictureID);
        }

        public IEnumerable<Album> GetAllAlbums()
        {
            return AlbumDAL.GetAllAlbums();
        }
        public Album GetAlbum(int albumID)
        {
            throw new NotImplementedException();
        }
        public bool AlbumExists(int albumID)
        {
            throw new NotImplementedException();
        }
            
        public void AddAlbum(Album album)
        {
            //Kontrollera objektet
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAllCategorys() //Ge möjlighet att requesta update? 
        {
            var allCategorys = HttpContext.Current.Cache["Categorys"] as IEnumerable<Category>; //Cahcar denna, kommer inte uppdateras
            if (allCategorys == null)
            {
                allCategorys = CategoryDAL.GetAllCategorys();
                HttpContext.Current.Cache.Insert("Categorys", allCategorys, null, DateTime.Now.AddMinutes(10), TimeSpan.Zero);
            }
            return allCategorys;
        }

        public void AddPictureToAlbum(Picture picture, int albumID)
        {
            PictureDAL.AddPictureToAlbum(picture, albumID);
        }
    }
}