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
                //TODO: Fixa länkar
                ImageNameLiteral.Text = imgName;
                ImageNameLiteral.Visible = true; 
            }

            //TODO: Fixa rätt meddelanden vid uppladdning
            if (Session["upload"] != null)
            {
                ////SuccessFullUploadPanel.Visible = true;
                ////SuccessFullUploadPanel.CssClass = "success";
                ////OutputLiteral.Text = "Bilden laddades upp";
                Session.Remove("upload");
            }
        }
    }
}