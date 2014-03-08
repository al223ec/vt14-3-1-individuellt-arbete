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

        public void DeletePicture(int pictureID)
        {
            PictureDAL.DeletePicture(pictureID);
        }
        public void UpdatePicture(Picture picture)
        {
            PictureDAL.UpdatePicture(picture);
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

        public void DeleteAlbum(int albumID)
        {
            AlbumDAL.DeleteAlbum(albumID); 
        }

        public void AddAlbum(Album album)
        {
            AlbumDAL.AddAlbum(album); 
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

        /// <summary>
        /// Uppdatera/lägg till bild till album, kan både ta emot en ny bild och en existerande bild
        /// </summary>
        /// <param name="picture">Picture som ska uppdateras</param>
        /// <param name="albumID">Vilket album bilden ska tillhöra</param>
        public void AddPictureToAlbum(Picture picture, int albumID)
        {
            //Validera picture
            if (picture.PictureID == 0) //Ny bild
            {
                PictureDAL.AddPictureToAlbum(picture, albumID);
            }
            else
            {
                PictureDAL.UpdateExistingPictureToAlbum(picture, albumID);
            }
        }
    }
}