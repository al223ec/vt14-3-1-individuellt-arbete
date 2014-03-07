using ImageGallery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ImageGallery.Pages.ImageGalleryPages
{
    public partial class ListPictures : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string imgName = Request.QueryString["name"];
            if (imgName != null)
            {
                MainImage.ImageUrl = "~/Content/Images/Penguins.jpg";
                MainImage.Visible = true;

                ImageNameLiteral.Text = imgName;
                ImageNameLiteral.Visible = true; 
            }
        }
    }
}