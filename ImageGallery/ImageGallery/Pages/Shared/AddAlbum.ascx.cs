using ImageGallery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ImageGallery.Pages.Shared
{
    public partial class AddAlbum : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {}

        public void AddAlbumFormView_InsertItem()
        {
            try
            {
                Page.Validate("InsertAlbum");
                if (Page.IsValid)
                {
                    var album = new Album();
                    if (Page.TryUpdateModel(album))
                    {
                        new Service().AddUpdateAlbum(album);
                    }
                }
            }
            catch (Exception)
            {
                throw new ApplicationException("Något oväntat gick fel");
            }
        }
    }
}