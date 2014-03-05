using ImageGallery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageGallery.Pages
{
    public abstract class PageBASE : System.Web.UI.UserControl
    {
        public int? AlbumID { get; set; } //kanske ska göra mer kollar på denna
        public string AlbumName { get; set; }

        private Service _service; //chacha denna??
        public Service Service { get { return _service ?? (_service = new Service()); } }

    }
}