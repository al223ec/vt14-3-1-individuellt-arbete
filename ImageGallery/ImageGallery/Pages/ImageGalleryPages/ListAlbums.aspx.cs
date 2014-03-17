using ImageGallery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ImageGallery.Pages.ImageGalleryPages
{
    public partial class ListAlbums : System.Web.UI.Page
    {
        private Service _service;
        public Service Service { get { return _service ?? (_service = new Service()); } }

        protected void Page_Load(object sender, EventArgs e)
        { }

        public IEnumerable<Album> AlbumListView_GetData()
        {
            return Service.GetAllAlbums();
        }


        public void AlbumListView_UpdateItem(int albumId)
        {
            try
            {
                Page.Validate("EditAlbum");
                if (!Page.IsValid)
                {
                    return;
                }
                Album album = Service.GetAlbum(albumId);
                if (album == null)
                {
                    ModelState.AddModelError("", String.Format("Kunde inte hitta det aktuella albummet {0}!!", albumId));
                    return;
                }

                if (TryUpdateModel(album))
                {
                    Service.AddUpdateAlbum(album);
                    Response.RedirectToRoute("Default");
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Något oväntat gick fel, vg försök igen");
            }
        }

        public void AlbumListView_DeleteItem(int albumID)
        {
            try
            {
                Service.DeleteAlbum(albumID);
                Response.RedirectToRoute("Default");
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (AlbumHavePicturesException)
            {
                ModelState.AddModelError("", "Albummet har tillhörande bilder vg tag bort dessa först och försök igen");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Något oväntat gick fel, vg försök igen");
            }
        }
    }
}