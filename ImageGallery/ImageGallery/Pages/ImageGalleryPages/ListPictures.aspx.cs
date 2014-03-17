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
            if (Session["successfull"] != null)
            {
                OutputPanel.Visible = true;
                HeaderOutputLiteral.Text = "Successfull";
                OutputLiteral.Text = Session["successfull"].ToString();
                Session.Remove("successfull");
            }
        }
    }
}