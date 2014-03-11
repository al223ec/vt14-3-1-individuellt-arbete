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
            //TODO: Fixa rätt meddelanden vid uppladdning
            if (Session["upload"] != null)
            {
                OutputPanel.Visible = true;
                HeaderOutputLiteral.Text = "Posten postades";
                OutputLiteral.Text = Session["upload"].ToString();
                Session.Remove("upload");
            }
        }
    }
}