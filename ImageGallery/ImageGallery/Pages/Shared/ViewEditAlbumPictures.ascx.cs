using ImageGallery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ImageGallery.Pages.Shared
{
    public partial class ViewEditAlbumPictures : System.Web.UI.UserControl
    {
        public int? AlbumID { get; set; }
        public string AlbumName { get; set; }

        private Service _service;
        public Service Service { get { return _service ?? (_service = new Service()); } }

        protected void Page_Load(object sender, EventArgs e)
        {
            AlbumNameLiteral.Text = AlbumName ?? "Albumname";
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IEnumerable<ImageGallery.Model.Picture> PictureListView_GetData()
        {
            if (AlbumID != null)
            {
                //return Service.GetAllPicturesFromAlbum((int)AlbumID);
                return Service.GetAllPictures();
            }
            return null; 
        }

        public void PictureListView_InsertItem()
        {
            var item = new ImageGallery.Model.Picture();
            TryUpdateModel(item);
            if (Page.ModelState.IsValid)
            {
                // Save changes here

            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void PictureListView_UpdateItem(int id)
        {
            ImageGallery.Model.Picture item = null;
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // The item wasn't found
                Page.ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }
            TryUpdateModel(item);
            if (Page.ModelState.IsValid)
            {
                // Save changes here, e.g. MyDataLayer.SaveChanges();

            }
        }
    }
}