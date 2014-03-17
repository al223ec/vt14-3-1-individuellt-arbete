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
        private int CurrentPictureID { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            AlbumNameLiteral.Text = AlbumName ?? "Albumnamet hittades inte";

            string imgName = Request.QueryString["name"];
            if (imgName != null)
            {
                ImageNameLiteral.Text = imgName;
                ImageNameLiteral.Visible = true;
            }
        }
        /// <summary>
        /// Returnerar alla bilder från det aktuella albummet, 
        /// </summary>
        /// <returns>Pictures alt null om inga bilder finns</returns>
        public IEnumerable<Picture> PictureListView_GetData()
        {
            if (AlbumID != null)
            {
                var picturesToDisplay = Service.GetAllPicturesFromAlbum((int)AlbumID);

                CurrentPictureID = Convert.ToInt32(Page.RouteData.Values["pictureID"]); //Sparar id:et till bilden som ska visas
                if (CurrentPictureID != 0)
                {
                    var currentPicture = picturesToDisplay.SingleOrDefault(pic => pic.PictureID == CurrentPictureID);
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
            if (CurrentPictureID == pictureID) //Tvungen att göra detta annars blir det en konflikt, process
            {
                MainImage.Visible = false;
                MainImage.ImageUrl = null;
                ImageNameLiteral.Visible = false;
            }
            Service.DeletePicture(pictureID);
            Session["successfull"] = "Bilden togs bort";
            Response.RedirectToRoute("ViewAlbumPictures", new { id = AlbumID });
            Context.ApplicationInstance.CompleteRequest();
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