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

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IEnumerable<Album> AlbumListView_GetData()
        {
            return Service.GetAllAlbums();
        }

        public void AlbumListView_InsertItem(Album album)
        {
            if (ModelState.IsValid)
            {
                Service.AddAlbum(album);
            }
        }
        // The id parameter name should match the DataKeyNames value set on the control
        public void AlbumListView_UpdateItem(int id)
        {
            ImageGallery.Model.Album item = null;
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Save changes here, e.g. MyDataLayer.SaveChanges();

            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void AlbumListView_DeleteItem(int albumID)
        {
            Service.DeleteAlbum(albumID);
        }
    }
}