using ImageGallery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ImageGallery.Pages.Shared
{
    public partial class UploadPicture : PageBASE
    {
        public int? PictureID { get; set; }
        //Om denna är set kommer denna class användas som edit också

        public FormViewMode ViewMode
        {
            get { return UploadFormView.DefaultMode; }
            set { UploadFormView.DefaultMode = value; }
        }
        private RadioButtonList RBL { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (PictureID != null)
            {
                MainImage.ImageUrl = "~/Content/Images/Penguins.jpg";
                MainImage.Visible = true;
                ViewMode = FormViewMode.Edit;
            }
        }


        public IEnumerable<Category> CategoryDropDownList_GetData()
        {
            return Service.GetAllCategorys();
        }

        public IEnumerable<Album> AlbumRadioButtonList_GetData()
        {
            return Service.GetAllAlbums();
        }

        public void AlbumRadioButtonList_DataBound(object sender, EventArgs e)
        {

            var rbl = sender as RadioButtonList;
            if (rbl != null && AlbumID != null)
            {
                RBL = rbl;
                for (int i = 0; i < rbl.Items.Count; i++)
                {
                    if (int.Parse(rbl.Items[i].Value) == AlbumID)
                    {
                        rbl.Items[i].Selected = true;
                    }
                }
            }

        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Picture UploadFormView_GetItem([RouteData]int pictureID)
        {
            return Service.GetPicture(pictureID);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void UploadFormView_UpdateItem(int pictureID)
        {
            Picture picture = Service.GetPicture(pictureID);
            if (picture == null)
            {
                // The item wasn't found
                Page.ModelState.AddModelError("", String.Format("Item with id {0} was not found", pictureID));
                return;
            }
            if (Page.TryUpdateModel(picture))
            {
                // Save changes here, e.g. MyDataLayer.SaveChanges();
                if (AlbumID != null)
                {
                    if (AlbumID == int.Parse(RBL.SelectedValue)) //Nytt album inte satt
                    {
                        Service.UpdatePicture(picture);
                    }
                    else
                    {
                        //throw new ApplicationException("Detta är inte implementerat fullt ut måste kunna läsa felkoder från msssql är angivet!!!");
                        Service.AddPictureToAlbum(picture, (int)AlbumID);
                    }
                }
                else
                {
                    throw new ApplicationException("Inget album är angivet!!!");
                }
            }
            else
            {
                //Modelstate error
            }
        }

        public void UploadFormView_InsertItem(Picture picture)
        {
            if (Page.ModelState.IsValid)
            {
                Service.AddPictureToAlbum(picture, int.Parse(RBL.SelectedValue));
            }
        }

        protected void ImageFileUpload_DataBinding(object sender, EventArgs e)
        {
            var fileUpload = sender as FileUpload;
            if (fileUpload != null)
            {
            }
        }
    }
}