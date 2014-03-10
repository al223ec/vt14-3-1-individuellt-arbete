using ImageGallery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ImageGallery.Pages.Shared
{
    public partial class ViewEditAlbumPictures : PageBASE
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AlbumNameLiteral.Text = AlbumName ?? "Albumnamet hittades inte";
        }
        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IEnumerable<Picture> PictureListView_GetData()
        {
            if (AlbumID != null)
            {
                var picturesToDisplay = Service.GetAllPicturesFromAlbum((int)AlbumID);
                
                var currentPictureID = Convert.ToInt32(Page.RouteData.Values["pictureID"]);
                if (currentPictureID != 0)
                {
                    var currentPicture = picturesToDisplay.Single(pic => pic.PictureID == currentPictureID);
                    if (currentPicture != null)
                    {
                        MainImage.Visible = true;
                        MainImage.ImageUrl = currentPicture.GetImagePath;
                    }
                }
                return picturesToDisplay; 
            }
            return null;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void PictureListView_DeleteItem(int pictureID)
        {
            Service.DeletePicture(pictureID); 
        }

        public IEnumerable<Category> CategoryDropDownList_GetData()
        {
            return Service.GetAllCategorys();
        }
        protected void PictureListView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            var label = e.Item.FindControl("CategoryValueLabel") as Label;
            if (label != null)
            {
                var pic = (Picture)e.Item.DataItem;
                label.Text = Service.GetAllCategorys().Single(cat => cat.CategoryID == pic.CategoryID).Value;
            }
        }
    }
}