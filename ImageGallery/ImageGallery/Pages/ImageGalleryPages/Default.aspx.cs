using ImageGallery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ImageGallery.Pages.ImageGalleryPages
{
    public partial class Default : System.Web.UI.Page
    {
        private Service _service;
        public Service Service { get { return _service ?? (_service = new Service()); } }
        protected void Page_Load(object sender, EventArgs e)
        {
            var pics = Service.GetPictures();
        }
    }
}