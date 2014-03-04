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
        private Service _service;
        public Service Service { get { return _service ?? (_service = new Service()); } }

        protected void Page_Load(object sender, EventArgs e)
        {
            string imgName = Request.QueryString["name"];
            if (imgName != null)
            {
                //if (Service.ImageExists(imgName))
                //{
                //    MainImage.ImageUrl = Service.GetImage(imgName).ImgPath;
                //    MainImage.Visible = true;
                //}
            }
            //int album; 
            //if(int.TryParse(Request.QueryString["album"], out album)){

            //}
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IEnumerable<ImageGallery.Model.Picture> PictureListView_GetData()
        {
            return Service.GetAllPictures();
            //return Service.GetAllPicturesFromAlbum(2);

        }
    }
}