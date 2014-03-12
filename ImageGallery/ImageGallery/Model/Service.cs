using ImageGallery.Model.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
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

        private PictureHandler _pictureHandler;
        public PictureHandler PictureHandler { get { return _pictureHandler ?? (_pictureHandler = new PictureHandler()); } }

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
            PictureHandler.DeletePictureFile(PictureDAL.GetPicture(pictureID));
            PictureDAL.DeletePicture(pictureID);
        }

        public void UpdatePicture(Picture picture)
        {
            ValidateObject(picture); //Validerar Picture utifrån dess dataAnnotations
            PictureDAL.UpdatePicture(picture);
        }
        public IEnumerable<Album> GetAllAlbums()
        {
            return AlbumDAL.GetAllAlbums();
        }
        public Album GetAlbum(int albumID)
        {
            return AlbumDAL.GetAlbum(albumID);
        }
        public string GetAlbumName(int albumID)
        {
            return AlbumDAL.GetAlbumName(albumID);
        }

        public bool AlbumExists(int albumID)
        {
            throw new NotImplementedException();
        }

        public void DeleteAlbum(int albumID)
        {
            AlbumDAL.DeleteAlbum(albumID);
        }

        public void AddUpdateAlbum(Album album)
        {
            ValidateObject(album);
            if (album.AlbumID != 0) //Existerar uppdaterar 
            {
                AlbumDAL.UpdateAlbum(album);
            }
            else
            {
                AlbumDAL.AddAlbum(album);
            }
        }

        /// <summary>
        /// Hämtar samtliga kategorier och chacar dessa
        /// </summary>
        /// <returns>Category objekt</returns>
        public IEnumerable<Category> GetAllCategorys(bool refresh = false) //Ge möjlighet att requesta update? 
        {
            var allCategorys = HttpContext.Current.Cache["Categorys"] as IEnumerable<Category>; //Cahcar denna, kommer inte uppdateras

            if (refresh)
            {
                allCategorys = CategoryDAL.GetAllCategorys();
            }

            if (allCategorys == null)
            {
                allCategorys = CategoryDAL.GetAllCategorys();
                HttpContext.Current.Cache.Insert("Categorys", allCategorys, null, DateTime.Now.AddMinutes(10), TimeSpan.Zero);
            }
            return allCategorys;
        }
        /// <summary>
        /// Validerar ett objekt utifrån dess DataAnnotations
        /// </summary>
        /// <param name="picture"></param>
        private void ValidateObject(Object obj)
        {
            ICollection<ValidationResult> validationResults;
            if (!obj.Validate(out validationResults))
            {
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }
        }

        /// <summary>
        /// Uppdatera/lägg till bild till album, kan både ta emot en ny bild och en existerande bild
        /// </summary>
        /// <param name="picture">Picture som ska uppdateras</param>
        /// <param name="albumID">Vilket album bilden ska tillghöra</param>
        public void AddPictureToAlbum(Picture picture, int albumID, Stream stream = null)
        {
            ValidateObject(picture); //Validerar Picture utifrån dess dataAnnotations
            if (picture.PictureID == 0) //Ny bild
            {
                if (PictureHandler.StreamIsValid(stream)) //Ny bild streamen kan egentligen inte vara null
                {
                    PictureDAL.AddPictureToAlbum(picture, albumID);
                    PictureHandler.SavePictureToFile(picture, stream); //Sparar filen, allt har gått väl
                }
                else
                {
                    //TODO: Streamen är null, det bör den inte vara
                    throw new ArgumentNullException("Det är inte valt någon bildfil!!");
                }
            }
            else
            {
                PictureDAL.UpdateExistingPictureToAlbum(picture, albumID);
            }
        }
    }
}