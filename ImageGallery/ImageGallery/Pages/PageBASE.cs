using ImageGallery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ImageGallery.Pages
{
    public abstract class PageBASE : System.Web.UI.UserControl
    {
        public int? AlbumID { get; set; } //kanske ska göra mer kollar på denna
        public string AlbumName
        {
            get
            {
                if(AlbumID != null)
                {
                    return Service.GetAlbumName((int)AlbumID);
                }
                return null; 
            }
        }

        private Service _service; //chacha denna??
        public Service Service { get { return _service ?? (_service = new Service()); } }
    }
}